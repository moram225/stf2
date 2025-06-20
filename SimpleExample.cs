using GroqSTT;

class SimpleExample
{    public static async Task TestDutchTranscriptionWithChunking()
    {
        // Get API key from environment variable
        var apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("Please set the GROQ_API_KEY environment variable");
            return;
        }
        
        using var groqSTT = new GroqSpeechToText(apiKey);

        try
        {
            var audioFilePath = @"audio\2.mp3";
            
            // Configure chunking parameters
            var chunkSize = 15; // seconds (minimum is 10 seconds)
            var overlapSize = 5; // seconds (minimum is 2 seconds)
            
            var chunkedResults = await groqSTT.TranscribeAudioInChunksAsync(
                audioFilePath: audioFilePath,
                chunkDurationSeconds: chunkSize,
                overlapSeconds: overlapSize,
                model: "whisper-large-v3-turbo",
                language: "nl",
                prompt: "Nederlandse spraak over kinderboeken"
            );
            
            // Final transcription
            var finalText = string.Join(" ", chunkedResults.Select(r => r.Text.Trim()));
            Console.WriteLine("=== FINAL TRANSCRIPTION ===");
            Console.WriteLine(finalText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
