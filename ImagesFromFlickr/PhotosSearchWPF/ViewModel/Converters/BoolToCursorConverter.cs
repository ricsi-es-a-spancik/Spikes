using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace PhotosSearchWPF.ViewModel.Converters
{
    public class BoolToCursorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var negateValue = parameter != null ? (bool)parameter : false;
            var boolValue = negateValue ? !(bool)value : (bool)value;

            if (boolValue)
                return Cursors.Hand;

            return Cursors.Arrow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
