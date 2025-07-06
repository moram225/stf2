using NAudio.Wave;
using System.Collections.Concurrent;
using GroqSTT;
using Newtonsoft.Json;
using System.Text;

namespace GroqSTT
{
    public class VoiceFormFiller : IDisposable
    {
        private readonly GroqSpeechToText _groqSTT;
        private readonly GroqChatCompletion _groqChat;
        private readonly WaveInEvent _waveIn;
        private readonly object _bufferLock = new object();
        
        private List<byte> _accumulatedAudio;
        private List<byte> _currentChunk;
        private readonly int _sampleRate = 16000;
        private readonly int _bitsPerSample = 16;
        private readonly int _channels = 1;
        private readonly string _tempDir;
        private bool _isRecording;
        private bool _disposed;
        private int _chunkCounter;
        private readonly int _chunkSizeMs = 3000; // 3 second chunks
        private readonly int _chunkSizeBytes;
        private Timer? _chunkTimer;
        
        private FormDefinition? _currentForm;
        private readonly StringBuilder _conversationHistory;
        private readonly Dictionary<string, string> _filledFields;

        public VoiceFormFiller(string groqApiKey)
        {
            _groqSTT = new GroqSpeechToText(groqApiKey);
            _groqChat = new GroqChatCompletion(groqApiKey);
            _accumulatedAudio = new List<byte>();
            _currentChunk = new List<byte>();
            _conversationHistory = new StringBuilder();
            _filledFields = new Dictionary<string, string>();
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
            _chunkCounter = 0;

            // Calculate chunk size in bytes (sample_rate * bits_per_sample / 8 * channels * seconds)
            _chunkSizeBytes = _sampleRate * _bitsPerSample / 8 * _channels * _chunkSizeMs / 1000;

            // Setup microphone recording
            _waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(_sampleRate, _bitsPerSample, _channels),
                BufferMilliseconds = 100
            };
            _waveIn.DataAvailable += OnDataAvailable;
            _waveIn.RecordingStopped += OnRecordingStopped;
        }

        public async Task StartFormFillingAsync(string formId)
        {            Console.WriteLine("🎤📋 Nederlandse Spraak Formulier Invuller");
            Console.WriteLine("==========================================");
            
            // Load the form
            if (!await LoadFormAsync(formId))
            {
                return;
            }

            ShowFormStructure();
            
            Console.WriteLine("\n🎤 Start continue Nederlandse spraakopname en formulier invulling...");
            Console.WriteLine("   De LLM vult automatisch velden in terwijl je Nederlands spreekt");
            Console.WriteLine("   Druk op ENTER om opname te stoppen en eindresultaten te bekijken");
            Console.WriteLine("   ⚠️  SPREEK ALLEEN NEDERLANDS - andere talen worden genegeerd");
            Console.WriteLine();

            StartRecording();
            
            // Wait for user to press Enter to stop
            Console.ReadLine();
            
            await StopRecordingAsync();
            
            ShowFinalResults();
        }

        private async Task<bool> LoadFormAsync(string formId)
        {
            try
            {
                var formPath = Path.Combine(Directory.GetCurrentDirectory(), "forms", $"{formId}.json");
                
                if (!File.Exists(formPath))
                {
                    Console.WriteLine($"❌ Form file not found: {formPath}");
                    Console.WriteLine("💡 Use option 4 to generate forms first, or option 6 to see available forms");
                    return false;
                }

                var jsonContent = await File.ReadAllTextAsync(formPath);
                _currentForm = JsonConvert.DeserializeObject<FormDefinition>(jsonContent);

                if (_currentForm == null)
                {
                    Console.WriteLine("❌ Failed to parse form JSON");
                    return false;
                }                Console.WriteLine($"📋 Nederlands formulier geladen: {_currentForm.FormTitle}");
                Console.WriteLine($"🆔 Formulier ID: {_currentForm.FormId}");
                Console.WriteLine($"📊 Totaal velden: {_currentForm.Fields.Count}");
                Console.WriteLine("🇳🇱 Dit formulier vereist Nederlandse invoer");
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading form: {ex.Message}");
                return false;
            }
        }

        private void ShowFormStructure()
        {
            if (_currentForm == null) return;            Console.WriteLine("\n📝 Nederlandse Formulier Structuur:");
            var fillableFields = _currentForm.Fields
                .Where(f => f.FieldType == "text" || f.FieldType == "textarea" || f.FieldType == "select")
                .Where(f => !string.IsNullOrEmpty(f.FieldName))
                .Take(15)
                .ToList();

            foreach (var field in fillableFields)
            {
                Console.WriteLine($"   • {field.FieldName} ({field.FieldType})");
            }

            if (fillableFields.Count < _currentForm.Fields.Count)
            {
                Console.WriteLine($"   ... en {_currentForm.Fields.Count - fillableFields.Count} meer velden");
            }
            
            Console.WriteLine($"\n📋 Dit is een '{_currentForm.FormTitle}' formulier");
            Console.WriteLine("🗣️  Spreek duidelijk Nederlandse informatie over het patiënt en de klacht");
        }

        private void StartRecording()
        {
            if (_isRecording) return;

            lock (_bufferLock)
            {
                _accumulatedAudio.Clear();
                _currentChunk.Clear();
                _conversationHistory.Clear();
                _filledFields.Clear();
            }

            _isRecording = true;
            _waveIn.StartRecording();

            // Start chunk processing timer
            _chunkTimer = new Timer(ProcessChunkCallback, null, _chunkSizeMs, _chunkSizeMs);
            
            Console.WriteLine("🔴 Opname gestart - spreek natuurlijk Nederlands over de formulier informatie...");
            Console.WriteLine("   🇳🇱 ALLEEN NEDERLANDSE SPRAAK wordt verwerkt");
            Console.WriteLine("   📋 Velden worden automatisch ingevuld met Nederlandse informatie");
        }

        private async Task StopRecordingAsync()
        {
            if (!_isRecording) return;

            _isRecording = false;
            _chunkTimer?.Dispose();
            _waveIn.StopRecording();

            Console.WriteLine("🛑 Opname gestopt. Laatste chunk wordt verwerkt...");

            // Process any remaining audio
            if (_currentChunk.Count > 0)
            {
                await ProcessCurrentChunkAsync();
            }
        }

        private void OnDataAvailable(object? sender, WaveInEventArgs e)
        {
            if (!_isRecording) return;

            lock (_bufferLock)
            {
                var audioData = e.Buffer.Take(e.BytesRecorded).ToArray();
                _accumulatedAudio.AddRange(audioData);
                _currentChunk.AddRange(audioData);
            }
        }

        private void ProcessChunkCallback(object? state)
        {
            if (!_isRecording) return;

            Task.Run(async () =>
            {
                try
                {
                    await ProcessCurrentChunkAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error processing chunk: {ex.Message}");
                }
            });
        }

        private async Task ProcessCurrentChunkAsync()
        {
            List<byte> chunkToProcess;
            
            lock (_bufferLock)
            {
                if (_currentChunk.Count < _chunkSizeBytes / 4) // Skip very small chunks
                {
                    return;
                }
                
                chunkToProcess = new List<byte>(_currentChunk);
                _currentChunk.Clear();
            }

            _chunkCounter++;
            
            try
            {
                // Save chunk to temporary file
                var audioFileName = $"chunk_{_chunkCounter:D3}.wav";
                var audioFilePath = Path.Combine(_tempDir, audioFileName);

                using (var waveFileWriter = new WaveFileWriter(audioFilePath, _waveIn.WaveFormat))
                {
                    waveFileWriter.Write(chunkToProcess.ToArray(), 0, chunkToProcess.Count);
                }                // Transcribe chunk with strict Dutch settings
                var transcription = await _groqSTT.TranscribeAudioAsync(
                    audioFilePath: audioFilePath,
                    model: "whisper-large-v3-turbo",
                    language: "nl", // Strict Dutch language
                    responseFormat: "json",
                    temperature: 0.0,
                    prompt: "Nederlandse veterinaire spraak. Alleen Nederlandse tekst transcriberen. Veterinaire termen in het Nederlands."
                );                if (!string.IsNullOrWhiteSpace(transcription.Text))
                {
                    // Basic Dutch language validation
                    if (IsLikelyDutch(transcription.Text))
                    {
                        Console.WriteLine($"🎧 Nederlandse spraak gehoord: \"{transcription.Text}\"");
                        _conversationHistory.AppendLine(transcription.Text);

                        // Send to LLM for form filling
                        await ProcessSpeechForFormFillingAsync(transcription.Text);
                    }
                    else
                    {
                        Console.WriteLine($"⚠️  Niet-Nederlandse spraak genegeerd: \"{transcription.Text}\"");
                        Console.WriteLine("   🇳🇱 Spreek alstublieft in het Nederlands");
                    }
                }

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
                Console.WriteLine($"❌ Error processing audio chunk: {ex.Message}");
            }
        }

        private async Task ProcessSpeechForFormFillingAsync(string speechText)
        {
            if (_currentForm == null) return;

            try
            {
                // Create form filling prompt
                var formFields = _currentForm.Fields
                    .Where(f => f.FieldType == "text" || f.FieldType == "textarea" || f.FieldType == "select")
                    .Where(f => !string.IsNullOrEmpty(f.FieldName))
                    .ToList();                var systemPrompt = CreateFormFillingSystemPrompt(formFields);
                var userMessage = $"Nederlandse spraak input: \"{speechText}\"\n\nConversatie tot nu toe:\n{_conversationHistory}";

                // Get LLM response with strict Dutch settings
                var response = await _groqChat.GenerateJsonAsync(
                    message: userMessage,
                    temperature: 0.1, // Lower temperature for more consistent Dutch responses
                    maxTokens: 800,
                    systemPrompt: systemPrompt
                );

                // Parse and apply updates
                await ProcessLLMFormResponse(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error in form filling: {ex.Message}");
            }
        }

        private string CreateFormFillingSystemPrompt(List<FormField> fields)
        {
            var fieldsJson = JsonConvert.SerializeObject(fields.Select(f => new { 
                name = f.FieldName, 
                type = f.FieldType,
                current_value = _filledFields.ContainsKey(f.FieldName) ? _filledFields[f.FieldName] : ""
            }), Formatting.Indented);            return $@"Je bent een intelligente Nederlandse assistent voor het invullen van veterinaire formulieren. Je spreekt en begrijpt ALLEEN NEDERLANDS.

FORMULIER VELDEN:
{fieldsJson}

NEDERLANDSE INSTRUCTIES:
1. Luister naar de Nederlandse spraak en haal relevante informatie eruit
2. Vul alleen velden in wanneer je DUIDELIJKE, SPECIFIEKE Nederlandse informatie hebt
3. Raad niets of maak geen aannames
4. Als informatie op meerdere velden van toepassing kan zijn, kies het meest passende
5. Voor namen: haal eigennamen (mensen, dieren, plaatsen) uit de Nederlandse tekst
6. Voor datums: converteer naar standaard formaat (DD-MM-YYYY of YYYY-MM-DD)
7. Voor medische termen: gebruik exacte Nederlandse veterinaire terminologie
8. Alle waarden moeten in het Nederlands zijn
9. Negeer niet-Nederlandse woorden of zinnen

NEDERLANDSE CONTEXT:
- Dit is een Nederlands veterinair formulier
- Patiënten zijn dieren (honden, katten, etc.)
- Eigenaren hebben Nederlandse namen en adressen
- Medische termen zijn in het Nederlands
- Datums in Nederlandse formaat

RESPONSE FORMAT (in het Nederlands):
Return JSON with:
{{
  ""updated_fields"": {{
    ""field_name"": ""nederlandse_waarde"",
    ""another_field"": ""nog_een_nederlandse_waarde""
  }},
  ""reasoning"": ""Nederlandse uitleg van wat je hebt ingevuld en waarom"",
  ""confidence"": ""high|medium|low""
}}

Vul alleen velden in die je bijwerkt met NIEUWE Nederlandse informatie. Herhaal geen bestaande waarden tenzij je ze corrigeert. Alle tekst moet in het Nederlands zijn.";
        }        private Task ProcessLLMFormResponse(string response)
        {
            try
            {
                var llmResponse = JsonConvert.DeserializeObject<dynamic>(response);
                var updatedFields = llmResponse?.updated_fields;
                var reasoning = llmResponse?.reasoning?.ToString() ?? "";
                var confidence = llmResponse?.confidence?.ToString() ?? "unknown";

                if (updatedFields != null)
                {
                    var hasUpdates = false;
                    
                    foreach (var field in updatedFields)
                    {
                        var fieldName = field.Name;
                        var fieldValue = field.Value?.ToString() ?? "";
                        
                        if (!string.IsNullOrEmpty(fieldValue) && 
                            (!_filledFields.ContainsKey(fieldName) || _filledFields[fieldName] != fieldValue))
                        {
                            _filledFields[fieldName] = fieldValue;
                            Console.WriteLine($"✅ Updated: {fieldName} = \"{fieldValue}\"");
                            hasUpdates = true;
                        }
                    }

                    if (hasUpdates)
                    {
                        if (!string.IsNullOrEmpty(reasoning))
                        {
                            Console.WriteLine($"💭 LLM reasoning: {reasoning}");
                        }
                        Console.WriteLine($"🎯 Confidence: {confidence}");
                        Console.WriteLine($"📊 Total filled fields: {_filledFields.Count}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error parsing LLM response: {ex.Message}");
                Console.WriteLine($"Raw response: {response}");
            }
            
            return Task.CompletedTask;
        }        private void ShowFinalResults()
        {
            Console.WriteLine("\n🏁 Eindresultaten Nederlandse Formulier Invulling");
            Console.WriteLine("================================================");
            
            if (_filledFields.Count == 0)
            {
                Console.WriteLine("❌ Geen velden ingevuld");
                Console.WriteLine("💡 Probeer opnieuw en spreek duidelijker Nederlands");
                return;
            }

            Console.WriteLine($"✅ Succesvol {_filledFields.Count} velden ingevuld met Nederlandse informatie:");
            Console.WriteLine();

            foreach (var field in _filledFields.OrderBy(f => f.Key))
            {
                Console.WriteLine($"📝 {field.Key}:");
                Console.WriteLine($"   → \"{field.Value}\"");
                Console.WriteLine();
            }

            // Show full conversation
            Console.WriteLine("🗣️ Volledige Nederlandse Conversatie:");
            Console.WriteLine(_conversationHistory.ToString());

            // Option to save results
            Console.WriteLine("💾 Resultaten opslaan? (j/n): ");
            var save = Console.ReadLine();
            if (save?.ToLower() == "j" || save?.ToLower() == "ja" || save?.ToLower() == "y" || save?.ToLower() == "yes")
            {
                SaveResults();
            }
        }

        private void SaveResults()
        {
            try
            {
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var filename = $"filled_form_{_currentForm?.FormId}_{timestamp}.json";
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "recordings", filename);

                Directory.CreateDirectory(Path.GetDirectoryName(filepath)!);

                var results = new
                {
                    form_id = _currentForm?.FormId,
                    form_title = _currentForm?.FormTitle,
                    timestamp = DateTime.Now,
                    filled_fields = _filledFields,
                    conversation = _conversationHistory.ToString(),
                    total_fields_filled = _filledFields.Count
                };

                File.WriteAllText(filepath, JsonConvert.SerializeObject(results, Formatting.Indented));
                Console.WriteLine($"💾 Results saved to: {filepath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving results: {ex.Message}");
            }
        }

        private void OnRecordingStopped(object? sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                Console.WriteLine($"Recording error: {e.Exception.Message}");
            }
        }

        public void Dispose()
        {
            if (_disposed) return;

            _isRecording = false;
            _chunkTimer?.Dispose();
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

        private bool IsLikelyDutch(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            
            // Convert to lowercase for checking
            var lowerText = text.ToLower();
            
            // Common Dutch words that indicate Dutch language
            var dutchIndicators = new[]
            {
                "de", "het", "een", "van", "en", "in", "op", "te", "met", "dat", "is", "niet", "voor", "ook",
                "naar", "hij", "zijn", "heeft", "dit", "kan", "werd", "maar", "uit", "over", "bij", "worden",
                "jaar", "tijd", "waar", "alle", "nog", "veel", "onder", "maken", "alleen", "komen", "wel",
                "door", "dieren", "hond", "kat", "patiënt", "eigenaar", "naam", "ja", "nee", "goed", "wat"
            };
            
            // Dutch veterinary terms
            var dutchVetTerms = new[]
            {
                "dierenarts", "veterinair", "patiënt", "hond", "kat", "konijn", "vogel", "eigenaar", "baasje",
                "vaccinatie", "medicijn", "behandeling", "onderzoek", "klacht", "symptoom", "ziek", "gezond",
                "braken", "diarree", "koorts", "pijn", "wond", "infectie", "allergie", "operatie"
            };
            
            // Check for Dutch indicators
            var words = lowerText.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var dutchWordCount = words.Count(word => dutchIndicators.Contains(word) || dutchVetTerms.Contains(word));
            
            // Dutch characteristics
            var hasDutchChars = lowerText.Contains("ij") || lowerText.Contains("aa") || lowerText.Contains("ee") || 
                               lowerText.Contains("oo") || lowerText.Contains("uu") || lowerText.Contains("ë");
            
            // Reject common English indicators
            var englishWords = new[] { "the", "and", "or", "but", "with", "have", "this", "that", "from", "they", "what" };
            var hasEnglish = words.Any(word => englishWords.Contains(word));
            
            // Must have Dutch words or Dutch characteristics, and not be primarily English
            return (dutchWordCount > 0 || hasDutchChars) && !hasEnglish;
        }

    }

    public class VoiceFormFillerExample
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
            }            Console.WriteLine("🇳🇱 Nederlandse Spraak Formulier Invuller");
            Console.WriteLine("=========================================");
            Console.WriteLine("BELANGRIJK: Dit systeem werkt ALLEEN met Nederlandse spraak!");
            Console.WriteLine("Andere talen worden automatisch genegeerd.");
            Console.WriteLine();
            
            Console.Write("Voer formulier ID in (bijv. 'custom_620bc591758b1303c0d466a4'): ");
            var formId = Console.ReadLine();
            
            if (string.IsNullOrEmpty(formId))
            {
                Console.WriteLine("❌ Geen formulier ID opgegeven");
                return;
            }

            Console.WriteLine($"📋 Formulier wordt geladen: {formId}");
            Console.WriteLine("🎤 Bereid je voor om in het Nederlands te spreken over:");
            Console.WriteLine("   • Patiënt informatie (dier naam, soort, leeftijd)");
            Console.WriteLine("   • Eigenaar gegevens (naam, adres, telefoon)");
            Console.WriteLine("   • Medische klachten en symptomen");
            Console.WriteLine("   • Behandelinformatie");
            Console.WriteLine();

            using var formFiller = new VoiceFormFiller(apiKey);
            await formFiller.StartFormFillingAsync(formId);
        }
    }
}
