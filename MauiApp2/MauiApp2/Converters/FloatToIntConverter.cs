namespace MauiApp2.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class FloatToIntConverter : IValueConverter
    {
        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (!float.TryParse(parameter as string, out float multipli))
            {
                multipli = 1;
            }

            value ??= 0;

            return (int)Math.Round(multipli * (float)value);
        }

        object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (!float.TryParse(parameter as string, out float dev))
            {
                dev = 1;
            }

            value ??= 0;

            return (int)value / dev;
        }
    }
}
