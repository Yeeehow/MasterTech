using Microsoft.Maui.Controls;
using System.Globalization;

namespace MasterTechParallelMAUI.Converters;
public sealed class BoolToTextColorConverter : IValueConverter
{
    public static readonly BoolToTextColorConverter Instance = new();
    public object Convert(object value, Type t, object p, CultureInfo c)
        => (value is bool b && b) ? Colors.White : Color.FromArgb("#222222");
    public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
}