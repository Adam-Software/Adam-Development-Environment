using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AdamDevelopmentEnvironment.Converters
{
    internal class DoubleToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double convertValue = (double)value;
            GridLength gridLength = new(convertValue);

            return gridLength;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GridLength val = (GridLength)value;

            return val.Value;
        }
    }
}
