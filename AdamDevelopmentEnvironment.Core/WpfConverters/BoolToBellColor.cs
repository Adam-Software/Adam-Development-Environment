using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace AdamDevelopmentEnvironment.Core.WpfConverters
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class BoolToBellColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isGrowlHapened = (bool)value;

            if (isGrowlHapened)
                return Color.DarkRed.Name;
            
            return Color.Black.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
