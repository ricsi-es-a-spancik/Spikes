using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PhotosSearchWPF.ViewModel.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var negateValue = parameter != null ? (bool)parameter : false;
            var boolValue = negateValue ? !(bool)value : (bool)value;

            if (boolValue)
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
