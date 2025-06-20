using GroqSTT;

class MicrophoneExample
{
    public static async Task TestRealTimeMicrophoneTranscription()
    {
        // Get API key from environment variable
        var apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("Please set the GROQ_API_KEY environment variable");
            return;
        }        // Configure real-time transcription parameters  
        var chunkSize = 10; // seconds (minimum is 10 seconds) - faster for testing
        var overlapSize = 2; // seconds (minimum is 2 seconds)

        using var transcriber = new RealTimeMicrophoneTranscriber(
            groqApiKey: apiKey,
            chunkDurationSeconds: chunkSize,
            overlapSeconds: overlapSize
        );        try
        {
            // Start recording
            transcriber.StartRecording();

            // Wait for user to stop
            Console.ReadKey();

            // Stop recording
            transcriber.StopRecording();

            // Wait a moment for final processing
            await Task.Delay(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
