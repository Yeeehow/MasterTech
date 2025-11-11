using Microsoft.Maui.Controls;

namespace MasterTechParallelMAUI.Views.Home
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private async void OnLanguageIconClicked(object sender, EventArgs e)
        {
            // Create the language popup and display it as a modal
            var languagePopup = new LanguagePopup();
            await Navigation.PushModalAsync(languagePopup);
        }
    }
}
