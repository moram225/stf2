using System.Text;
using Newtonsoft.Json;

namespace GroqSTT
{
    public class GroqChatCompletion : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string BaseUrl = "https://api.groq.com/openai/v1/chat/completions";
        private bool _disposed = false;

        public GroqChatCompletion(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }        public async Task<ChatCompletionResponse> GenerateResponseAsync(
            string message,
            string model = "meta-llama/llama-4-scout-17b-16e-instruct",
            double temperature = 0.7,
            int maxTokens = 1024,
            string? systemPrompt = null)
        {
            var messages = new List<ChatMessage>();
            
            // Add system message if provided
            if (!string.IsNullOrEmpty(systemPrompt))
            {
                messages.Add(new ChatMessage { Role = "system", Content = systemPrompt });
            }
            
            // Add user message
            messages.Add(new ChatMessage { Role = "user", Content = message });

            var request = new ChatCompletionRequest
            {
                Model = model,
                Messages = messages,
                Temperature = temperature,
                MaxTokens = maxTokens
            };

            var jsonContent = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(BaseUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Groq API error: {response.StatusCode} - {responseContent}");
                }

                var result = JsonConvert.DeserializeObject<ChatCompletionResponse>(responseContent);
                return result ?? throw new InvalidOperationException("Failed to deserialize response");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error calling Groq Chat API: {ex.Message}", ex);
            }
        }        public async Task<string> GenerateTextAsync(
            string message,
            string model = "meta-llama/llama-4-scout-17b-16e-instruct",
            double temperature = 0.7,
            int maxTokens = 1024,
            string? systemPrompt = null)
        {
            var response = await GenerateResponseAsync(message, model, temperature, maxTokens, systemPrompt);
            return response.Choices.FirstOrDefault()?.Message?.Content ?? string.Empty;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _httpClient?.Dispose();
                _disposed = true;
            }
        }
    }

    // Data models for chat completion
    public class ChatCompletionRequest
    {
        [JsonProperty("model")]
        public string Model { get; set; } = string.Empty;

        [JsonProperty("messages")]
        public List<ChatMessage> Messages { get; set; } = new();

        [JsonProperty("temperature")]
        public double Temperature { get; set; } = 0.7;

        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; } = 1024;
    }

    public class ChatMessage
    {
        [JsonProperty("role")]
        public string Role { get; set; } = string.Empty;

        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;
    }

    public class ChatCompletionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("object")]
        public string Object { get; set; } = string.Empty;

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; } = string.Empty;

        [JsonProperty("choices")]
        public List<ChatChoice> Choices { get; set; } = new();

        [JsonProperty("usage")]
        public ChatUsage Usage { get; set; } = new();
    }

    public class ChatChoice
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("message")]
        public ChatMessage Message { get; set; } = new();

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; } = string.Empty;
    }

    public class ChatUsage
    {
        [JsonProperty("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonProperty("completion_tokens")]
        public int CompletionTokens { get; set; }

        [JsonProperty("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
