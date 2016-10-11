using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PhotosSearchWPF.ViewModel.Converters
{
    public class ImageToImageIconConverter : IValueConverter
    {
        private static string ImageIconPath = @"../Images/Icons/Image_16x.png";
        private static string ImageWarningIconPath = @"../Images/Icons/ImageWarning_16x.png";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriPath = (bool)value ? ImageIconPath : ImageWarningIconPath;
            return new BitmapImage(new Uri(uriPath, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
