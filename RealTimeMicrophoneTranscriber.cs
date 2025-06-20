using NAudio.Wave;
using System.Collections.Concurrent;
using GroqSTT;

namespace GroqSTT
{    public class RealTimeMicrophoneTranscriber : IDisposable
    {
        private readonly GroqSpeechToText _groqSTT;
        private readonly WaveInEvent _waveIn;
        private readonly Timer _chunkTimer;
        private readonly ConcurrentQueue<byte[]> _audioBuffer;        private readonly object _bufferLock = new object();
        
        private List<byte> _currentAudioData;
        private List<byte> _fullAudioData; // Store the entire recording session
        private readonly int _sampleRate = 16000;
        private readonly int _bitsPerSample = 16;
        private readonly int _channels = 1;
        private readonly int _chunkDurationSeconds;
        private readonly int _overlapSeconds;
        private readonly string _tempDir;        private bool _isRecording;
        private bool _disposed;
        private int _chunkCounter;

        public RealTimeMicrophoneTranscriber(
            string groqApiKey,
            int chunkDurationSeconds = 10, // minimum 10 seconds for Groq
            int overlapSeconds = 2)
        {
            if (chunkDurationSeconds < 10)
                throw new ArgumentException("Chunk duration must be at least 10 seconds");
            
            if (overlapSeconds < 2)
                throw new ArgumentException("Overlap must be at least 2 seconds");

            _groqSTT = new GroqSpeechToText(groqApiKey);
            _chunkDurationSeconds = chunkDurationSeconds;
            _overlapSeconds = overlapSeconds;            _currentAudioData = new List<byte>();
            _fullAudioData = new List<byte>(); // Initialize full session storage
            _audioBuffer = new ConcurrentQueue<byte[]>();
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
            _chunkCounter = 0;

            // Setup microphone recording
            _waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(_sampleRate, _bitsPerSample, _channels),
                BufferMilliseconds = 100
            };
            _waveIn.DataAvailable += OnDataAvailable;
            _waveIn.RecordingStopped += OnRecordingStopped;

            // Setup timer for chunk processing (every chunkDuration - overlap seconds)
            var intervalMs = (_chunkDurationSeconds - _overlapSeconds) * 1000;
            _chunkTimer = new Timer(ProcessAudioChunk, null, Timeout.Infinite, intervalMs);
        }        public void StartRecording()
        {
            if (_isRecording) return;

            Console.WriteLine("🎤 Starting microphone recording...");
            Console.WriteLine($"Chunk size: {_chunkDurationSeconds}s, Overlap: {_overlapSeconds}s");
            Console.WriteLine("Press any key to stop recording");
            Console.WriteLine();

            // Clear previous session data
            lock (_bufferLock)
            {
                _currentAudioData.Clear();
                _fullAudioData.Clear();
            }
            _chunkCounter = 0;

            _isRecording = true;
            _waveIn.StartRecording();
            
            // Start the chunk processing timer immediately, then repeat every (chunkDuration - overlap) seconds
            var intervalMs = (_chunkDurationSeconds - _overlapSeconds) * 1000;
            _chunkTimer.Change(TimeSpan.FromSeconds(_chunkDurationSeconds), TimeSpan.FromMilliseconds(intervalMs));
        }public void StopRecording()
        {
            if (!_isRecording) return;

            Console.WriteLine("🛑 Stopping recording...");
            _isRecording = false;
            _waveIn.StopRecording();
            _chunkTimer.Change(Timeout.Infinite, Timeout.Infinite);
            
            // Process any remaining audio
            if (_currentAudioData.Count > 0)
            {
                ProcessFinalChunk();
            }
            
            // Save the full session audio
            SaveFullSessionAudio();
        }private void OnDataAvailable(object? sender, WaveInEventArgs e)
        {
            if (!_isRecording) return;

            lock (_bufferLock)
            {
                // Add new audio data to the current buffer
                _currentAudioData.AddRange(e.Buffer.Take(e.BytesRecorded));
                
                // Also add to full session recording
                _fullAudioData.AddRange(e.Buffer.Take(e.BytesRecorded));
            }
        }

        private void OnRecordingStopped(object? sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                Console.WriteLine($"Recording error: {e.Exception.Message}");
            }
        }        private async void ProcessAudioChunk(object? state)
        {
            if (!_isRecording) return;

            byte[] chunkData;
            lock (_bufferLock)
            {
                if (_currentAudioData.Count == 0) return;

                // Calculate how much audio we need for this chunk
                var bytesPerSecond = _sampleRate * _channels * (_bitsPerSample / 8);
                var chunkSizeInBytes = bytesPerSecond * _chunkDurationSeconds;

                if (_currentAudioData.Count < chunkSizeInBytes) return;

                // Extract chunk with current size
                chunkData = _currentAudioData.Take(chunkSizeInBytes).ToArray();

                // Remove processed data but keep overlap
                var overlapSizeInBytes = bytesPerSecond * _overlapSeconds;
                var removeBytes = chunkSizeInBytes - overlapSizeInBytes;
                _currentAudioData.RemoveRange(0, removeBytes);
            }

            // Process this chunk
            _chunkCounter++;
            Console.WriteLine($"Processing chunk {_chunkCounter}...");
            await ProcessChunkAsync(chunkData);
        }        private async Task ProcessChunkAsync(byte[] audioData)
        {
            try
            {
                var chunkFileName = $"mic_chunk_{_chunkCounter:D3}.wav";
                var chunkFilePath = Path.Combine(_tempDir, chunkFileName);

                // Save audio data to WAV file
                using (var waveFileWriter = new WaveFileWriter(chunkFilePath, _waveIn.WaveFormat))
                {
                    waveFileWriter.Write(audioData, 0, audioData.Length);
                }

                // Transcribe the chunk
                var result = await _groqSTT.TranscribeAudioAsync(
                    audioFilePath: chunkFilePath,
                    model: "whisper-large-v3-turbo",
                    language: "nl",
                    responseFormat: "json",
                    temperature: 0.0,
                    prompt: "Nederlandse spraak"
                );

                // Display real-time streaming result
                Console.WriteLine($"Chunk {_chunkCounter}: {result.Text}");

                // Cleanup chunk file
                try
                {
                    File.Delete(chunkFilePath);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chunk {_chunkCounter}: [Error: {ex.Message}]");
            }
        }

        private async void ProcessFinalChunk()
        {
            if (_currentAudioData.Count == 0) return;

            try
            {
                _chunkCounter++;
                var chunkFileName = $"mic_chunk_final_{_chunkCounter:D3}.wav";
                var chunkFilePath = Path.Combine(_tempDir, chunkFileName);

                // Save remaining audio data
                using (var waveFileWriter = new WaveFileWriter(chunkFilePath, _waveIn.WaveFormat))
                {
                    waveFileWriter.Write(_currentAudioData.ToArray(), 0, _currentAudioData.Count);
                }

                var result = await _groqSTT.TranscribeAudioAsync(
                    audioFilePath: chunkFilePath,
                    model: "whisper-large-v3-turbo",
                    language: "nl",
                    responseFormat: "json",
                    temperature: 0.0,
                    prompt: "Nederlandse spraak"
                );

                Console.WriteLine($"Final Chunk {_chunkCounter}: {result.Text}");

                try
                {
                    File.Delete(chunkFilePath);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Final Chunk {_chunkCounter}: [Error: {ex.Message}]");
            }
        }        private void SaveFullSessionAudio()
        {
            if (_fullAudioData == null || _fullAudioData.Count == 0)
            {
                Console.WriteLine("No audio data to save.");
                return;
            }

            try
            {
                // Create recordings directory if it doesn't exist
                var recordingsDir = Path.Combine(Directory.GetCurrentDirectory(), "recordings");
                Directory.CreateDirectory(recordingsDir);

                // Create filename with timestamp
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var filename = $"full_session_{timestamp}.wav";
                var filePath = Path.Combine(recordingsDir, filename);

                Console.WriteLine($"💾 Saving full session audio to: recordings/{filename}");

                // Save the complete audio data as a WAV file
                using (var waveFileWriter = new WaveFileWriter(filePath, _waveIn.WaveFormat))
                {
                    waveFileWriter.Write(_fullAudioData.ToArray(), 0, _fullAudioData.Count);
                }

                // Calculate and display recording duration
                var bytesPerSecond = _sampleRate * _channels * (_bitsPerSample / 8);
                var durationSeconds = (double)_fullAudioData.Count / bytesPerSecond;
                
                Console.WriteLine($"✅ Full session saved successfully!");
                Console.WriteLine($"   Duration: {durationSeconds:F1} seconds");
                Console.WriteLine($"   Size: {_fullAudioData.Count / 1024.0:F1} KB");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving full session: {ex.Message}");
            }
        }public void Dispose()
        {
            if (_disposed) return;

            StopRecording();
            _chunkTimer?.Dispose();
            _waveIn?.Dispose();
            _groqSTT?.Dispose();

            // Cleanup temp directory
            try
            {
                if (Directory.Exists(_tempDir))
                    Directory.Delete(_tempDir, true);
            }
            catch
            {
                // Ignore cleanup errors
            }

            _disposed = true;
        }
    }
}
