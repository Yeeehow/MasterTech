using System.Windows.Input;
using Microsoft.Maui.Controls;
using MasterTechParallelMAUI.Services;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;

namespace MasterTechParallelMAUI.ViewModels
{
    public class LanguagePopupViewModel : BaseViewModel
    {
        private string selectedLanguage = "en"; // Default to English
        private readonly TranslationService _translationService;

        public ICommand SelectLanguageCommand { get; }
        public ICommand SavePreferenceCommand { get; }
        public ICommand ClosePopupCommand { get; }

        // Constructor with API Key
        public LanguagePopupViewModel(string apiKey)
        {
            _translationService = new TranslationService(apiKey);
            SelectLanguageCommand = new Command<string>(OnSelectLanguage);
            SavePreferenceCommand = new Command(OnSavePreference);
            ClosePopupCommand = new Command(OnClosePopup);
        }

        private void OnSelectLanguage(string languageCode)
        {
            selectedLanguage = languageCode;
        }

        private async void OnSavePreference()
        {
            // Simulate translating text in the app
            await TranslateAppTextAsync(selectedLanguage);

            // Close the popup after saving preference
            ClosePopupCommand.Execute(null);
        }

        private async Task TranslateAppTextAsync(string languageCode)
        {
            string translatedText;

            // Example of translating static text (you can translate dynamic UI text here)
            string textToTranslate = "Welcome to Coles!";  // Replace with dynamic text in your app

            // Translate text to selected language
            translatedText = await _translationService.TranslateTextAsync(textToTranslate, languageCode);

            // Apply the translated text wherever needed
            // For example, update the UI text dynamically (you could bind this to your UI).
            // For now, let's just show a toast message as a placeholder for actual translation
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Toast.Make($"Translated to {languageCode}: {translatedText}").Show();
            });
        }

        private void OnClosePopup()
        {
            // Close the popup
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
