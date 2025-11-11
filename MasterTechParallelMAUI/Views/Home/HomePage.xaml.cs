using Microsoft.Maui.Controls;

namespace MasterTechParallelMAUI.Views.Home
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // Handle language icon click
        private async void OnLanguageIconClicked(object sender, EventArgs e)
        {
            // Pass your Google API key here
            string apiKey = "GOOGLE_API_KEY_Here";

            // Create the language popup and display it as a modal
            var languagePopup = new LanguagePopup(apiKey);
            await Navigation.PushModalAsync(languagePopup);
        }
    }
}
