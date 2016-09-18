using FlickrNet;
using System;
using System.Globalization;
using System.Windows.Data;

namespace PhotosSearchWPF.ViewModel
{
    public class UrlEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            var photo = value as string;
            return photo != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
