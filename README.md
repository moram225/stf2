# Groq Speech-to-Text for Dutch with C#

This project demonstrates how to use Groq's Whisper Turbo model for Dutch speech transcription with both file-based chunking and real-time microphone recording.

## Features

- **Dutch Language Support**: Configured for `nl` language code
- **Whisper Turbo Model**: Uses `whisper-large-v3-turbo` for best price/performance
- **File Chunking**: Process large audio files in configurable chunks with overlap
- **Real-time Microphone**: Live transcription from microphone with chunked processing
- **Configurable Parameters**: Adjustable chunk size and overlap (minimum constraints apply)
- **Error Handling**: Comprehensive error management

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

## Usage Options

When you run the application, you'll see:

```
=== Groq AI Services ===
1. File transcription (chunked)
2. Real-time microphone transcription
3. LLaMA chat (text generation)

Choose option (1, 2, or 3):
```

### Option 1: File Transcription

Processes audio files in chunks:
- **Chunk size**: 20 seconds (configurable, minimum 10 seconds)
- **Overlap**: 3 seconds (configurable, minimum 2 seconds)
- Shows real-time chunk results and final combined transcription

### Option 2: Real-time Microphone

Records from microphone and transcribes in real-time:
- **Chunk size**: 15 seconds (configurable, minimum 10 seconds)  
- **Overlap**: 3 seconds (configurable, minimum 2 seconds)
- **Full Session Recording**: Saves complete audio session as WAV file after recording stops
- Press any key to stop recording
- Shows transcription results as each chunk is processed
- Automatically saves full recording to `recordings/full_session_YYYYMMDD_HHMMSS.wav`

### Option 3: LLaMA Chat (Text Generation)

Interactive chat using Groq's LLaMA-4-Scout model:
- **Model**: `meta-llama/llama-4-scout-17b-16e-instruct`
- **Temperature**: 0.7 (configurable for creativity vs consistency)
- **Max Tokens**: 512 (configurable response length)
- **System Prompt**: Configurable assistant behavior
- Type your messages and get AI responses
- Type 'quit' or 'exit' to end the conversation

## Configuration

### File Transcription (SimpleExample.cs)
```csharp
var chunkSize = 20; // seconds (minimum is 10 seconds)
var overlapSize = 3; // seconds (minimum is 2 seconds)
```

### Microphone Transcription (MicrophoneExample.cs)
```csharp
var chunkSize = 15; // seconds (minimum is 10 seconds)
var overlapSize = 3; // seconds (minimum is 2 seconds)
```

## Model Information

### Speech-to-Text (Whisper)
- **whisper-large-v3-turbo**: $0.04/hour, best price/performance for Dutch
- **Language**: Dutch (`nl`)
- **Max File Size**: 25MB (free tier), 100MB (dev tier)
- **Supported Formats**: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, webm

### Text Generation (LLaMA)
- **meta-llama/llama-4-scout-17b-16e-instruct**: Advanced language model for conversational AI
- **Context Window**: Large context for detailed conversations
- **Capabilities**: Text generation, question answering, creative writing, code assistance

## Dependencies

- **.NET 9.0**
- **Newtonsoft.Json**: JSON serialization
- **Microsoft.Extensions.Http**: HTTP client management
- **NAudio**: Audio recording and processing
- **FFmpeg**: Audio format conversion (must be in PATH)
