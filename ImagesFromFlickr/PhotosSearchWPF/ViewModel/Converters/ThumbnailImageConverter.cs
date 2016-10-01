using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PhotosSearchWPF.ViewModel.Converters
{
    public class ThumbnailImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = new BitmapImage();

            source.BeginInit();
            var thumbnailUrl = value as string;
            var uriString = thumbnailUrl ?? @"../Images/no-thumb.png";
            source.UriSource = new Uri(uriString);
            source.EndInit();

            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
