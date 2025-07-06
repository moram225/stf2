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
4. Generate form JSON files
5. LLaMA JSON responses
6. Analyze form structure
7. Voice chat with LLaMA
8. Voice-powered form filling (AUTO)
9. List available forms

Choose option (1-9):
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

### Option 4: Generate Form JSON Files

Converts CSV form analysis data into structured JSON files:
- **Source**: Reads from `forms labels/detailed_fields_analysis.csv`
- **Output**: Creates individual JSON files in `forms/` folder
- **Structure**: Each form gets its own JSON file with complete field definitions
- **Metadata**: Includes generation timestamp and source information
- **Field Details**: Field names, IDs, types, classes, values, and validation flags
- Automatically parses 100+ forms from the CSV data

### Option 5: LLaMA JSON Responses

Get AI-generated responses in JSON format:
- **Input**: Provide a text prompt or question
- **Output**: Receive a structured JSON response
- **Metadata**: Includes model used, token usage, and response time
- Useful for integrating AI responses into applications

### Option 6: Analyze Form Structure

Examines and describes the structure of a form:
- **Input**: Provide a form ID
- **Output**: Receive a detailed description of the form's fields and structure
- Helps understand what data a form collects and how it's organized

### Option 7: Voice Chat with LLaMA

Interactive voice chat with the LLM:
- **Speech-to-Text**: Converts your speech to text using Whisper Turbo
- **LLM Integration**: Sends transcribed text to LLaMA for intelligent responses  
- **Dual Input**: Use voice recording OR type text directly
- **JSON Responses**: Gets structured responses with metadata
- Commands: `record` (start voice), `quit` (exit), or type text directly

### Option 8: Voice-Powered Form Filling (AUTO) 🆕

**Intelligent, continuous form filling via voice input**:
- **Automatic Processing**: Just press record and speak naturally - no buttons to press!
- **Continuous STT**: Records and processes 3-second audio chunks automatically
- **Smart Field Mapping**: LLM intelligently matches speech to appropriate form fields
- **Real-time Updates**: See fields being filled as you speak
- **Multi-language Support**: Works with Dutch and other languages
- **Confidence Scoring**: Shows LLM's confidence in field assignments
- **Session Recording**: Saves complete conversation and results

**How it works**:
1. Select a form ID (use option 9 to list available forms)
2. Press ENTER to start recording
3. Speak naturally about the information (e.g., "The patient is a dog named Buddy, age 5 years, owner is John Smith")
4. LLM automatically fills relevant fields as it gets information
5. Press ENTER again to stop and see final results
6. Option to save filled form and conversation history

### Option 9: List Available Forms

Shows all available veterinary forms with:
- **Form ID**: Unique identifier for each form
- **Form Title**: Human-readable form name  
- **Field Count**: Number of fillable fields (text, textarea, select)
- **Quick Preview**: Essential information for form selection

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
