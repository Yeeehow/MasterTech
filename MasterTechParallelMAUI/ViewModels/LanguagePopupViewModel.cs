using CommunityToolkit.Maui.Alerts;
using MasterTechParallelMAUI.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MasterTechParallelMAUI.ViewModels
{
    public class LanguagePopupViewModel : BaseViewModel
    {
        private string selectedLanguage = "en"; // Default to English

        public ICommand SelectLanguageCommand { get; }
        public ICommand SavePreferenceCommand { get; }
        public ICommand ClosePopupCommand { get; }

        public LanguagePopupViewModel()
        {
            SelectLanguageCommand = new Command<string>(OnSelectLanguage);
            SavePreferenceCommand = new Command(OnSavePreference);
            ClosePopupCommand = new Command(OnClosePopup);
        }

        private void OnSelectLanguage(string languageCode)
        {
            selectedLanguage = languageCode;

            // Show an alert or message with the selected language
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Toast.Make($"Language selected: {languageCode}").Show();
            });
        }

        private void OnSavePreference()
        {
            // Simulate translation, for now, we'll just show a message
            // TODO: Integrate AI translation API here

            if (selectedLanguage == "zh")
            {
                // Simulate translation to Chinese
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Toast.Make("App text translated to Chinese.").Show();
                });
            }
            else if (selectedLanguage == "es")
            {
                // Simulate translation to Spanish
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Toast.Make("App text translated to Spanish.").Show();
                });
            }

            // Close the popup after saving preference
            ClosePopupCommand.Execute(null);
        }

        private void OnClosePopup()
        {
            // Close the popup
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
