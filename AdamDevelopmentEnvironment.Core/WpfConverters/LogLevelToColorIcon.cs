using AdamDevelopmentEnvironment.Core.WpfConverterModels;
using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using HandyControl.Tools;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AdamDevelopmentEnvironment.Core.WpfConverters
{
    public class LogLevelToColorIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            LogLevel inputValue = (LogLevel)value;

            return inputValue switch
            {
                LogLevel.Verbose => new ColorIcon("Blue", ResourceHelper.GetResource<Geometry>("InfoGeometry")),
                LogLevel.Debug => new ColorIcon("Blue", ResourceHelper.GetResource<Geometry>("InfoGeometry")),
                LogLevel.Information => new ColorIcon("Blue", ResourceHelper.GetResource<Geometry>("InfoGeometry")),
                LogLevel.Warning => new ColorIcon("OrangeRed", ResourceHelper.GetResource<Geometry>("WarningGeometry")),
                LogLevel.Error => new ColorIcon("Red", ResourceHelper.GetResource<Geometry>("ErrorGeometry")),
                LogLevel.Fatal => new ColorIcon("Red", ResourceHelper.GetResource<Geometry>("FatalGeometry")),
                _ => new ColorIcon(null, null),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
