using System;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AppFogWP7.ViewModel
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object convertedValue = null;
            if (targetType == typeof(System.Windows.Visibility))
            {
                const Visibility invisibleValue = Visibility.Collapsed;

                try
                {
                    bool sourceBoolean = (bool)value;
                    convertedValue = sourceBoolean ? Visibility.Visible : invisibleValue;
                }
                catch (Exception)
                {
                    convertedValue = Visibility.Visible;
                }
            }
            return convertedValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
