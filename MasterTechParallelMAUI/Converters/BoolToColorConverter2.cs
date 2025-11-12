using Microsoft.Maui.Controls;
using System.Globalization;

namespace MasterTechParallelMAUI.Converters
{
    public sealed class BoolToColorConverter2 : IValueConverter
    {
        public static readonly BoolToColorConverter2 Instance = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isUser = (bool)value;
            return isUser ? Color.FromArgb("#1976D2") : Color.FromArgb("#EEEEEE"); // user blue, bot gray
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
