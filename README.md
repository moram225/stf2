# Groq Speech-to-Text for Dutch with C#

This project demonstrates how to use Groq's Whisper Turbo model for Dutch speech transcription.

## Setup

1. **Get your Groq API Key**
   - Sign up at [Groq Console](https://console.groq.com)
   - Generate an API key

2. **Set Environment Variable**
   ```powershell
   $env:GROQ_API_KEY = "your_actual_api_key_here"
   ```

3. **Install Dependencies**
   ```powershell
   dotnet restore GroqSTT.csproj
   ```

4. **Run the Application**
   ```powershell
   dotnet run --project GroqSTT.csproj
   ```

## Features

- **Dutch Language Support**: Configured for `nl` language code
- **Whisper Turbo Model**: Uses `whisper-large-v3-turbo` for best price/performance
- **Word-level Timestamps**: Optional detailed transcription with timing
- **Error Handling**: Comprehensive error management
- **Audio Format Support**: Works with MP3, WAV, M4A, and other formats

## Usage Examples

### Basic Transcription
```csharp
using var groqSTT = new GroqSpeechToText(apiKey);

var result = await groqSTT.TranscribeAudioAsync(
    audioFilePath: "path/to/dutch_audio.mp3",
    model: "whisper-large-v3-turbo",
    language: "nl"
);

Console.WriteLine(result.Text);
```

### Advanced with Timestamps
```csharp
var result = await groqSTT.TranscribeAudioAsync(
    audioFilePath: "path/to/dutch_audio.mp3",
    model: "whisper-large-v3-turbo",
    language: "nl",
    responseFormat: "verbose_json",
    timestampGranularities: new[] { "word" }
);

foreach (var word in result.Words)
{
    Console.WriteLine($"{word.Start:F2}s: {word.Text}");
}
```

## Model Information

- **whisper-large-v3-turbo**: $0.04/hour, best price/performance for Dutch
- **Language**: Dutch (`nl`)
- **Max File Size**: 25MB (free tier), 100MB (dev tier)
- **Supported Formats**: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, webm

## Audio Files in Project

Your project includes Dutch audio files:
- `Meester David heeft een grote kinderboekenprijs gewonnen.mp3`
- `2.mp3`

These will be automatically transcribed when you run the program.
