using OpenAI.Chat;

namespace MyApi.Services
{
    public class AIService
    {
        private readonly ChatClient _chat;

        public AIService(IConfiguration config)
        {
            var apiKey = config["OpenAI:ApiKey"];
            Console.WriteLine($"[DEBUG] Usando OpenAI Key: {apiKey.Substring(0, 6)}…");
            _chat = new ChatClient(model: "gpt-3.5-turbo", apiKey);
        }

        public async Task<string> GetResponseAsync(string input)
        {
            ChatCompletion completion = await _chat.CompleteChatAsync(input);
            return completion.Content[0].Text;
        }
    }
}
