using Microsoft.Maui.Controls;

namespace MasterTechParallelMAUI.Views.Profile
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        // Handle button click to edit profile
        private async void OnEditProfileClicked(object sender, EventArgs e)
        {
            // Example: Navigate to the EditProfilePage (you can define this page separately)
            //await Navigation.PushAsync(new EditProfilePage());
        }

        // Handle button click to change password
        private async void OnChangePasswordClicked(object sender, EventArgs e)
        {
            // Navigate to ChangePasswordPage (you can define this page separately)
            //await Navigation.PushAsync(new ChangePasswordPage());
        }

        // Handle button click to sign out
        private void OnSignOutClicked(object sender, EventArgs e)
        {
            // Example: Sign out logic goes here (clear session, navigate to login, etc.)
            // Navigation.InsertPageBefore(new LoginPage(), this);
            // Navigation.PopToRootAsync();
        }
    }
}
