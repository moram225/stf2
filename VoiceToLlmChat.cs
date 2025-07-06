using NAudio.Wave;
using System.Collections.Concurrent;
using GroqSTT;
using Newtonsoft.Json;

namespace GroqSTT
{
    public class VoiceToLlmChat : IDisposable
    {
        private readonly GroqSpeechToText _groqSTT;
        private readonly GroqChatCompletion _groqChat;
        private readonly WaveInEvent _waveIn;
        private readonly object _bufferLock = new object();
        
        private List<byte> _currentAudioData;
        private readonly int _sampleRate = 16000;
        private readonly int _bitsPerSample = 16;
        private readonly int _channels = 1;
        private readonly string _tempDir;
        private bool _isRecording;
        private bool _disposed;
        private int _recordingCounter;

        public VoiceToLlmChat(string groqApiKey)
        {
            _groqSTT = new GroqSpeechToText(groqApiKey);
            _groqChat = new GroqChatCompletion(groqApiKey);
            _currentAudioData = new List<byte>();
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
            _recordingCounter = 0;

            // Setup microphone recording
            _waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(_sampleRate, _bitsPerSample, _channels),
                BufferMilliseconds = 100
            };
            _waveIn.DataAvailable += OnDataAvailable;
            _waveIn.RecordingStopped += OnRecordingStopped;
        }        public async Task StartVoiceChatAsync()
        {
            Console.WriteLine("🎤🤖 Voice Chat with LLaMA");
            Console.WriteLine("========================");
            Console.WriteLine("Commands:");
            Console.WriteLine("  'record' - Start voice recording");
            Console.WriteLine("  'quit' - Exit chat");
            Console.WriteLine("  Or type text directly to send to LLaMA");
            Console.WriteLine();

            while (true)
            {
                Console.Write("💬 Enter command or message: ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) continue;

                if (input.ToLower() == "quit" || input.ToLower() == "exit")
                {
                    Console.WriteLine("👋 Goodbye!");
                    break;
                }
                else if (input.ToLower() == "record")
                {
                    await ProcessVoiceInputAsync();
                }
                else if (input.ToLower() == "help")
                {
                    ShowHelp();
                }
                else
                {
                    // Text input - send directly to LLM
                    await ProcessTextInputAsync(input);
                }

                Console.WriteLine();
            }
        }

        private async Task ProcessVoiceInputAsync()
        {
            Console.WriteLine("🔴 Recording started... Press ENTER to stop recording");
            
            StartRecording();
            
            // Wait for user to press Enter
            Console.ReadLine();
            
            StopRecording();
            Console.WriteLine("🛑 Recording stopped. Processing...");

            if (_currentAudioData.Count == 0)
            {
                Console.WriteLine("❌ No audio recorded");
                return;
            }

            Console.WriteLine("🎧 Transcribing speech...");

            try
            {
                // Save audio to temporary file
                _recordingCounter++;
                var audioFileName = $"voice_input_{_recordingCounter:D3}.wav";
                var audioFilePath = Path.Combine(_tempDir, audioFileName);

                using (var waveFileWriter = new WaveFileWriter(audioFilePath, _waveIn.WaveFormat))
                {
                    waveFileWriter.Write(_currentAudioData.ToArray(), 0, _currentAudioData.Count);
                }

                // Transcribe speech
                var transcription = await _groqSTT.TranscribeAudioAsync(
                    audioFilePath: audioFilePath,
                    model: "whisper-large-v3-turbo",
                    language: "nl",
                    responseFormat: "json",
                    temperature: 0.0,
                    prompt: "Nederlandse spraak"
                );

                Console.WriteLine($"📝 You said: \"{transcription.Text}\"");

                if (string.IsNullOrWhiteSpace(transcription.Text))
                {
                    Console.WriteLine("❌ No speech detected");
                    return;
                }

                // Send to LLM
                await ProcessTextInputAsync(transcription.Text);

                // Cleanup
                try
                {
                    File.Delete(audioFilePath);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error processing voice: {ex.Message}");
            }
        }

        private async Task ProcessTextInputAsync(string text)
        {
            try
            {
                Console.WriteLine("🤖 LLaMA is thinking...");

                // Get JSON response from LLM
                var response = await _groqChat.GenerateJsonAsync(
                    message: text,
                    temperature: 0.7,
                    maxTokens: 512,
                    systemPrompt: "You are a helpful assistant. Always respond with valid JSON containing 'response' (your answer) and 'metadata' (with language, intent, and confidence fields). Detect the language of the input and respond in the same language."
                );

                // Parse and display the response
                try
                {
                    var parsed = JsonConvert.DeserializeObject<dynamic>(response);
                    var aiResponse = parsed?.response?.ToString() ?? "No response";
                    var metadata = parsed?.metadata;

                    Console.WriteLine($"🤖 LLaMA: {aiResponse}");
                    
                    if (metadata != null)
                    {
                        Console.WriteLine($"📊 Metadata:");
                        Console.WriteLine($"   Language: {metadata.language}");
                        if (metadata.intent != null)
                            Console.WriteLine($"   Intent: {metadata.intent}");
                        if (metadata.confidence != null)
                            Console.WriteLine($"   Confidence: {metadata.confidence}");
                    }
                }
                catch
                {
                    // Fallback to raw response if JSON parsing fails
                    Console.WriteLine($"🤖 LLaMA: {response}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error getting LLM response: {ex.Message}");
            }
        }

        private void StartRecording()
        {
            if (_isRecording) return;

            lock (_bufferLock)
            {
                _currentAudioData.Clear();
            }

            _isRecording = true;
            _waveIn.StartRecording();
        }

        private void StopRecording()
        {
            if (!_isRecording) return;

            _isRecording = false;
            _waveIn.StopRecording();
        }

        private void OnDataAvailable(object? sender, WaveInEventArgs e)
        {
            if (!_isRecording) return;

            lock (_bufferLock)
            {
                _currentAudioData.AddRange(e.Buffer.Take(e.BytesRecorded));
            }
        }

        private void OnRecordingStopped(object? sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                Console.WriteLine($"Recording error: {e.Exception.Message}");
            }
        }        private void ShowHelp()
        {
            Console.WriteLine("📖 Voice Chat Commands:");
            Console.WriteLine("   'record': Start voice recording (press ENTER to stop)");
            Console.WriteLine("   Text + ENTER: Send text message to LLaMA");
            Console.WriteLine("   'help': Show this help");
            Console.WriteLine("   'quit' or 'exit': End chat");
            Console.WriteLine();
        }

        public void Dispose()
        {
            if (_disposed) return;

            StopRecording();
            _waveIn?.Dispose();
            _groqSTT?.Dispose();
            _groqChat?.Dispose();

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

    public class VoiceChatExample
    {
        public static async Task RunAsync()
        {
            // Get API key from environment variable
            var apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("❌ Please set the GROQ_API_KEY environment variable");
                Console.WriteLine("   Example: $env:GROQ_API_KEY = \"your_api_key_here\"");
                return;
            }

            using var voiceChat = new VoiceToLlmChat(apiKey);
            await voiceChat.StartVoiceChatAsync();
        }
    }
}
