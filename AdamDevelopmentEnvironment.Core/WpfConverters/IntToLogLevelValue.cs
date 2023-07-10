using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AdamDevelopmentEnvironment.Core.WpfConverters
{
    public class IntToLogLevelValue : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int inputValue = (int)value;

            LogLevel logLevel;

            try
            {
                logLevel = (LogLevel)Enum.ToObject(typeof(LogLevel), inputValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return logLevel;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            LogLevel inputValue = (LogLevel)value;

            return (int)inputValue;
        }
    }
}
