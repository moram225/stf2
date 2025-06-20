using GroqSTT;

namespace GroqSTT
{
    public class LlamaExample
    {
        public static async Task RunAsync()
        {
            // Get API key from environment variable
            var apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("❌ Please set the GROQ_API_KEY environment variable");
                Console.WriteLine("   Example: $env:GROQ_API_KEY = \"your_api_key_here\"");
                return;
            }

            Console.WriteLine("🤖 Groq LLaMA-4-Scout Chat Example");
            Console.WriteLine("==================================");
            Console.WriteLine();

            using var groqChat = new GroqChatCompletion(apiKey);

            while (true)
            {
                Console.Write("You: ");
                var userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput) || userInput.ToLower() == "quit" || userInput.ToLower() == "exit")
                {
                    Console.WriteLine("👋 Goodbye!");
                    break;
                }

                try
                {
                    Console.Write("🤖 LLaMA: ");
                      var response = await groqChat.GenerateTextAsync(
                        message: userInput,
                        model: "meta-llama/llama-4-scout-17b-16e-instruct",
                        temperature: 0.7,
                        maxTokens: 512,
                        systemPrompt: "You are a helpful assistant. Respond concisely and clearly."
                    );

                    Console.WriteLine(response);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                    Console.WriteLine();
                }
            }
        }
    }
}
