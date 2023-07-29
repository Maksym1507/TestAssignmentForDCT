using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestAssignmentForDCT.Converters
{
    public class NumericFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return value!;
            }

            double doubleValue = double.Parse(value.ToString()!, NumberStyles.Any, CultureInfo.InvariantCulture);

            return doubleValue.ToString("F2", CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
