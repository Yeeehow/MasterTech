using Microsoft.Maui.Controls;
using System.Globalization;

namespace MasterTechParallelMAUI.Converters;
public sealed class BoolToLayoutOptionsConverter : IValueConverter
{
    public static readonly BoolToLayoutOptionsConverter Instance = new();
    public object Convert(object value, Type t, object p, CultureInfo c)
        => (value is bool b && b) ? LayoutOptions.End : LayoutOptions.Start;
    public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
}