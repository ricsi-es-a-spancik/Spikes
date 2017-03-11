namespace UITest_SampleApplication.ViewModel.Converters
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class AvatarPathToBitmapImageConverter : IValueConverter
    {
        private const string DEFAULT_AVATAR_PATH = @"Resources\Characters\default.png";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = Path.GetFullPath(value as string ?? DEFAULT_AVATAR_PATH);
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path, UriKind.Absolute);
            bitmap.EndInit();

            return bitmap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
