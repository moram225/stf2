using GroqSTT;

class Program
{    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Groq AI Services ===");
        Console.WriteLine("1. File transcription (chunked)");
        Console.WriteLine("2. Real-time microphone transcription");
        Console.WriteLine("3. LLaMA chat (text generation)");
        Console.WriteLine();
        Console.Write("Choose option (1, 2, or 3): ");
        
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
            default:
                Console.WriteLine("Invalid choice. Running file transcription...");
                await SimpleExample.TestDutchTranscriptionWithChunking();
                break;
        }
    }
}
