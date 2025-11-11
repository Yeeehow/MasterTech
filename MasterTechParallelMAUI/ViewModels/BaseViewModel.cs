using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MasterTechParallelMAUI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;
        private string title = string.Empty;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}