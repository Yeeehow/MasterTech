using Google.Cloud.Translation.V2;
using System;
using System.Threading.Tasks;

namespace MasterTechParallelMAUI.Services
{
    public class TranslationService
    {
        private readonly TranslationClient _client;

        public TranslationService(string apiKey)
        {
            _client = TranslationClient.CreateFromApiKey(apiKey); // Use your Google API Key
        }

        // Translate text asynchronously
        public async Task<string> TranslateTextAsync(string text, string targetLanguage)
        {
            try
            {
                var response = await _client.TranslateTextAsync(text, targetLanguage);
                return response.TranslatedText;
            }
            catch (Exception ex)
            {
                // Handle exceptions here (e.g., API errors, network issues)
                Console.WriteLine($"Error during translation: {ex.Message}");
                return text;  // Return original text in case of error
            }
        }
    }
}
