using GroqSTT;

class Program
{    static async Task Main(string[] args)
    {        Console.WriteLine("=== Groq AI Services ===");
        Console.WriteLine("1. File transcription (chunked)");
        Console.WriteLine("2. Real-time microphone transcription");
        Console.WriteLine("3. LLaMA chat (text generation)");
        Console.WriteLine("4. Generate form JSON files");
        Console.WriteLine("5. LLaMA JSON responses");
        Console.WriteLine("6. Analyze form structure");
        Console.WriteLine("7. Voice chat with LLaMA");
        Console.WriteLine("8. Voice-powered form filling (AUTO)");
        Console.WriteLine("9. List available forms");
        Console.WriteLine();
        Console.Write("Choose option (1-9): ");
        
        var choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                await SimpleExample.TestDutchTranscriptionWithChunking();
                break;
            case "2":
                await MicrophoneExample.TestRealTimeMicrophoneTranscription();
                break;
            case "3":
                await LlamaExample.RunAsync();
                break;
            case "4":
                await FormJsonGenerator.GenerateFormsAsync();
                break;            case "5":
                await LlamaJsonExample.RunAsync();
                break;            case "6":
                Console.Write("Enter form ID to analyze (or 'list' to see available forms): ");
                var formId = Console.ReadLine();
                if (!string.IsNullOrEmpty(formId))
                {
                    if (formId.ToLower() == "list")
                    {
                        await FormAnalyzer.ListAvailableFormsAsync();
                    }
                    else
                    {
                        await FormAnalyzer.AnalyzeFormAsync(formId);
                    }
                }
                break;            case "7":
                await VoiceChatExample.RunAsync();
                break;
            case "8":
                await VoiceFormFillerExample.RunAsync();
                break;
            case "9":
                await FormAnalyzer.ListAvailableFormsAsync();
                break;
            default:
                Console.WriteLine("Invalid choice. Running file transcription...");
                await SimpleExample.TestDutchTranscriptionWithChunking();
                break;
        }
    }
}
