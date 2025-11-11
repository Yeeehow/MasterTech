using Microsoft.Maui.Controls;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using MasterTechParallelMAUI.ViewModels;

namespace MasterTechParallelMAUI.Views
{
    public partial class LanguagePopup : ContentPage
    {
        public LanguagePopup(string apiKey)
        {
            InitializeComponent();
            BindingContext = new LanguagePopupViewModel(apiKey); // Pass API key to ViewModel
        }
    }
}
