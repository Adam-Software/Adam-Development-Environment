using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AdamDevelopmentEnvironment.Core.WpfConverters
{
    [ValueConversion(typeof(bool), typeof(Geometry))]
    public class BoolToBellGeometry : IValueConverter
    {
        private static readonly Geometry geometryBell =
            Geometry.Parse("M21,19V20H3V19L5,17V11C5,7.9 7.03,5.17 10,4.29C10,4.19 10,4.1 10,4A2,2 0 0,1 12,2A2,2 0 0,1 14,4C14,4.1 14,4.19 14,4.29C16.97,5.17 19,7.9 19,11V17L21,19M14,21A2,2 0 0,1 12,23A2,2 0 0,1 10,21");
        
        private static readonly Geometry geometryBellOffOutline = 
            Geometry.Parse("M20.84,22.73L18.11,20H3V19L5,17V11C5,9.86 5.29,8.73 5.83,7.72L1.11,3L2.39,1.73L22.11,21.46L20.84,22.73M19,15.8V11C19,7.9 16.97,5.17 14,4.29C14,4.19 14,4.1 14,4A2,2 0 0,0 12,2A2,2 0 0,0 10,4C10,4.1 10,4.19 10,4.29C9.39,4.47 8.8,4.74 8.26,5.09L19,15.8M12,23A2,2 0 0,0 14,21H10A2,2 0 0,0 12,23Z");
        
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isSilentModeEnabled = (bool)value;

            if (isSilentModeEnabled)
                return geometryBellOffOutline;

            return geometryBell;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
