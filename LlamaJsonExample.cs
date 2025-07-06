using GroqSTT;
using Newtonsoft.Json;

namespace GroqSTT
{
    // Example data structures for JSON responses
    public class PersonInfo
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Occupation { get; set; } = "";
        public List<string> Hobbies { get; set; } = new();
    }

    public class TaskResponse
    {
        public string Task { get; set; } = "";
        public string Status { get; set; } = "";
        public List<string> Steps { get; set; } = new();
        public int EstimatedMinutes { get; set; }
    }

    public class LlamaJsonExample
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

            Console.WriteLine("🤖 Groq LLaMA-4-Scout JSON Response Example");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Text responses");
            Console.WriteLine("2. JSON responses");
            Console.WriteLine("3. Structured JSON (typed)");
            Console.WriteLine();

            using var groqChat = new GroqChatCompletion(apiKey);

            while (true)
            {
                Console.Write("Choose mode (1-3) or 'quit': ");
                var mode = Console.ReadLine();

                if (string.IsNullOrEmpty(mode) || mode.ToLower() == "quit" || mode.ToLower() == "exit")
                {
                    Console.WriteLine("👋 Goodbye!");
                    break;
                }

                Console.Write("Your message: ");
                var userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput)) continue;

                try
                {
                    switch (mode)
                    {
                        case "1":
                            await DemoTextResponse(groqChat, userInput);
                            break;
                        case "2":
                            await DemoJsonResponse(groqChat, userInput);
                            break;
                        case "3":
                            await DemoStructuredJsonResponse(groqChat, userInput);
                            break;
                        default:
                            Console.WriteLine("Invalid mode. Choose 1, 2, or 3.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                }

                Console.WriteLine();
            }
        }

        private static async Task DemoTextResponse(GroqChatCompletion groqChat, string userInput)
        {
            Console.WriteLine("📝 Text Response:");
            var response = await groqChat.GenerateTextAsync(
                message: userInput,
                systemPrompt: "You are a helpful assistant. Respond concisely and clearly."
            );
            Console.WriteLine(response);
        }

        private static async Task DemoJsonResponse(GroqChatCompletion groqChat, string userInput)
        {
            Console.WriteLine("🔧 JSON Response:");
            var jsonResponse = await groqChat.GenerateJsonAsync(
                message: userInput,
                systemPrompt: "You are a helpful assistant. Always respond with valid JSON that includes 'response' and 'metadata' fields."
            );
            
            // Pretty print the JSON
            try
            {
                var parsed = JsonConvert.DeserializeObject(jsonResponse);
                var formatted = JsonConvert.SerializeObject(parsed, Formatting.Indented);
                Console.WriteLine(formatted);
            }
            catch
            {
                Console.WriteLine(jsonResponse);
            }
        }

        private static async Task DemoStructuredJsonResponse(GroqChatCompletion groqChat, string userInput)
        {
            Console.WriteLine("🎯 Structured JSON Response:");
            
            // Try to determine what kind of structured response to request
            if (userInput.ToLower().Contains("person") || userInput.ToLower().Contains("people"))
            {
                var personInfo = await groqChat.GenerateJsonAsync<PersonInfo>(
                    message: $"Based on this input, create a person profile: {userInput}",
                    systemPrompt: "Create a person profile with name, age, occupation, and hobbies. Respond only with valid JSON matching the PersonInfo structure."
                );

                if (personInfo != null)
                {
                    Console.WriteLine($"Name: {personInfo.Name}");
                    Console.WriteLine($"Age: {personInfo.Age}");
                    Console.WriteLine($"Occupation: {personInfo.Occupation}");
                    Console.WriteLine($"Hobbies: {string.Join(", ", personInfo.Hobbies)}");
                }
            }
            else if (userInput.ToLower().Contains("task") || userInput.ToLower().Contains("how to"))
            {
                var taskResponse = await groqChat.GenerateJsonAsync<TaskResponse>(
                    message: $"Break down this task: {userInput}",
                    systemPrompt: "Break down the task into steps with status and estimated time. Respond only with valid JSON matching the TaskResponse structure."
                );

                if (taskResponse != null)
                {
                    Console.WriteLine($"Task: {taskResponse.Task}");
                    Console.WriteLine($"Status: {taskResponse.Status}");
                    Console.WriteLine($"Estimated Time: {taskResponse.EstimatedMinutes} minutes");
                    Console.WriteLine("Steps:");
                    for (int i = 0; i < taskResponse.Steps.Count; i++)
                    {
                        Console.WriteLine($"  {i + 1}. {taskResponse.Steps[i]}");
                    }
                }
            }
            else
            {
                // Generic JSON response
                await DemoJsonResponse(groqChat, userInput);
            }
        }
    }
}
