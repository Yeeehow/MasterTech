using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterTechParallelMAUI.ViewModels;

namespace MasterTechParallelMAUI.Views
{
    public partial class LanguagePopup : ContentPage
    {
        public LanguagePopup()
        {
            InitializeComponent();
            BindingContext = new LanguagePopupViewModel();
        }
    }

}
