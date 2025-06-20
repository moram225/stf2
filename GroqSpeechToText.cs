using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;

namespace GroqSTT
{    public class GroqSpeechToText : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string BaseUrl = "https://api.groq.com/openai/v1/audio/transcriptions";
        private bool _disposed = false;

        public GroqSpeechToText(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<TranscriptionResponse> TranscribeAudioAsync(
            string audioFilePath,
            string model = "whisper-large-v3-turbo",
            string language = "nl",
            string responseFormat = "json",
            double temperature = 0.0,
            string? prompt = null,
            string[]? timestampGranularities = null)
        {
            if (!File.Exists(audioFilePath))
                throw new FileNotFoundException($"Audio file not found: {audioFilePath}");

            using var form = new MultipartFormDataContent();
            
            // Add audio file
            var audioBytes = await File.ReadAllBytesAsync(audioFilePath);
            var audioContent = new ByteArrayContent(audioBytes);
            audioContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/mpeg");
            form.Add(audioContent, "file", Path.GetFileName(audioFilePath));

            // Add required parameters
            form.Add(new StringContent(model), "model");
            form.Add(new StringContent(language), "language");
            form.Add(new StringContent(responseFormat), "response_format");
            form.Add(new StringContent(temperature.ToString("F1", System.Globalization.CultureInfo.InvariantCulture)), "temperature");

            // Add optional parameters
            if (!string.IsNullOrEmpty(prompt))
            {
                form.Add(new StringContent(prompt), "prompt");
            }

            if (timestampGranularities != null && timestampGranularities.Length > 0)
            {
                var timestampJson = JsonConvert.SerializeObject(timestampGranularities);
                form.Add(new StringContent(timestampJson), "timestamp_granularities");
            }

            try
            {
                var response = await _httpClient.PostAsync(BaseUrl, form);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Groq API request failed: {response.StatusCode} - {responseContent}");
                }

                var transcription = JsonConvert.DeserializeObject<TranscriptionResponse>(responseContent);
                return transcription ?? throw new InvalidOperationException("Failed to deserialize transcription response");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error calling Groq API: {ex.Message}", ex);
            }
        }        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                }
                _disposed = true;
            }
        }        public async Task<List<ChunkedTranscriptionResult>> TranscribeAudioInChunksAsync(
            string audioFilePath,
            int chunkDurationSeconds, // Minimum is 10 seconds
            int overlapSeconds = 2, // Minimum is 2 seconds  
            string model = "whisper-large-v3-turbo",
            string language = "nl",
            string responseFormat = "json",
            double temperature = 0.0,
            string? prompt = null)
        {
            if (!File.Exists(audioFilePath))
                throw new FileNotFoundException($"Audio file not found: {audioFilePath}");

            if (chunkDurationSeconds < 10)
                throw new ArgumentException("Chunk duration must be at least 10 seconds (Groq minimum billing)");

            if (overlapSeconds < 2)
                throw new ArgumentException("Overlap must be at least 2 seconds");

            var results = new List<ChunkedTranscriptionResult>();
            
            // Get audio duration first
            var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);

            try
            {                // Get audio duration using ffprobe
                var durationInfo = await GetAudioDurationAsync(audioFilePath);
                
                // Calculate chunks with overlap
                var stepSize = chunkDurationSeconds - overlapSeconds;
                var totalChunks = (int)Math.Ceiling((durationInfo - overlapSeconds) / stepSize);

                for (int i = 0; i < totalChunks; i++)
                {
                    var startTime = i * stepSize;
                    var endTime = Math.Min(startTime + chunkDurationSeconds, durationInfo);
                    var actualDuration = endTime - startTime;

                    // Skip chunks shorter than 1 second
                    if (actualDuration < 1.0)
                        break;

                    // Create chunk file
                    var chunkFileName = $"chunk_{i:D3}_{startTime:F0}s-{endTime:F0}s.wav";
                    var chunkFilePath = Path.Combine(tempDir, chunkFileName);

                    // Extract chunk using ffmpeg
                    await ExtractAudioChunkAsync(audioFilePath, chunkFilePath, startTime, actualDuration);                    // Transcribe chunk
                    try
                    {
                        var chunkResult = await TranscribeAudioAsync(
                            audioFilePath: chunkFilePath,
                            model: model,
                            language: language,
                            responseFormat: responseFormat,
                            temperature: temperature,
                            prompt: prompt
                        );

                        // Real-time chunk transcription output
                        Console.WriteLine($"Chunk {i + 1}: {chunkResult.Text}");

                        results.Add(new ChunkedTranscriptionResult
                        {
                            ChunkIndex = i,
                            StartTime = startTime,
                            EndTime = endTime,
                            Duration = actualDuration,
                            Text = chunkResult.Text,
                            ChunkFilePath = chunkFileName
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Chunk {i + 1}: [Error: {ex.Message}]");
                        // Add empty result to maintain sequence
                        results.Add(new ChunkedTranscriptionResult
                        {
                            ChunkIndex = i,
                            StartTime = startTime,
                            EndTime = endTime,
                            Duration = actualDuration,
                            Text = $"[Error transcribing chunk: {ex.Message}]",
                            ChunkFilePath = chunkFileName
                        });
                    }
                }
            }
            finally
            {                // Cleanup temp directory
                try
                {
                    if (Directory.Exists(tempDir))
                        Directory.Delete(tempDir, true);
                }
                catch
                {
                    // Silently ignore cleanup errors
                }
            }

            return results;
        }        private async Task<double> GetAudioDurationAsync(string audioFilePath)
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "ffprobe",
                    Arguments = $"-v quiet -show_entries format=duration -of csv=p=0 \"{audioFilePath}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                using var process = Process.Start(startInfo);
                if (process == null)
                    throw new InvalidOperationException("Could not start ffprobe process");

                var output = await process.StandardOutput.ReadToEndAsync();
                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                    throw new InvalidOperationException($"ffprobe failed with exit code {process.ExitCode}");

                // Parse duration using invariant culture to handle decimal separator
                if (double.TryParse(output.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var duration))
                    return duration;

                throw new InvalidOperationException($"Could not parse duration: {output}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Could not get audio duration. Make sure ffmpeg/ffprobe is installed and in PATH. Error: {ex.Message}", ex);
            }
        }        private async Task ExtractAudioChunkAsync(string inputFile, string outputFile, double startTime, double duration)
        {
            try
            {
                // Use invariant culture for decimal formatting to ensure dot separator
                var startTimeStr = startTime.ToString("F3", System.Globalization.CultureInfo.InvariantCulture);
                var durationStr = duration.ToString("F3", System.Globalization.CultureInfo.InvariantCulture);
                
                var startInfo = new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = $"-i \"{inputFile}\" -ss {startTimeStr} -t {durationStr} -ar 16000 -ac 1 -c:a pcm_s16le \"{outputFile}\" -y",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using var process = Process.Start(startInfo);
                if (process == null)
                    throw new InvalidOperationException("Could not start ffmpeg process");

                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    var error = await process.StandardError.ReadToEndAsync();
                    throw new InvalidOperationException($"ffmpeg failed with exit code {process.ExitCode}: {error}");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Could not extract audio chunk. Make sure ffmpeg is installed and in PATH. Error: {ex.Message}", ex);
            }
        }
    }

    public class TranscriptionResponse
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("language")]
        public string? Language { get; set; }

        [JsonProperty("duration")]
        public double? Duration { get; set; }

        [JsonProperty("words")]
        public Word[]? Words { get; set; }

        [JsonProperty("segments")]
        public Segment[]? Segments { get; set; }
    }

    public class Word
    {
        [JsonProperty("word")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("end")]
        public double End { get; set; }
    }

    public class Segment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("seek")]
        public int Seek { get; set; }

        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("end")]
        public double End { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("tokens")]
        public int[]? Tokens { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("avg_logprob")]
        public double AvgLogprob { get; set; }

        [JsonProperty("compression_ratio")]
        public double CompressionRatio { get; set; }

        [JsonProperty("no_speech_prob")]
        public double NoSpeechProb { get; set; }
    }

    public class ChunkedTranscriptionResult
    {
        public int ChunkIndex { get; set; }
        public double StartTime { get; set; }
        public double EndTime { get; set; }
        public double Duration { get; set; }
        public string Text { get; set; } = string.Empty;
        public string ChunkFilePath { get; set; } = string.Empty;
    }
}
