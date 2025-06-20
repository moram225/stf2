using GroqSTT;

class Program
{
    static async Task Main(string[] args)
    {
        await SimpleExample.TestDutchTranscriptionWithChunking();
    }
}
