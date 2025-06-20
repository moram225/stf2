using GroqSTT;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Groq Speech-to-Text with Chunking ===");
        Console.WriteLine("1. File transcription (chunked)");
        Console.WriteLine("2. Real-time microphone transcription");
        Console.WriteLine();
        Console.Write("Choose option (1 or 2): ");
        
        var choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                await SimpleExample.TestDutchTranscriptionWithChunking();
                break;
            case "2":
                await MicrophoneExample.TestRealTimeMicrophoneTranscription();
                break;
            default:
                Console.WriteLine("Invalid choice. Running file transcription...");
                await SimpleExample.TestDutchTranscriptionWithChunking();
                break;
        }
    }
}
