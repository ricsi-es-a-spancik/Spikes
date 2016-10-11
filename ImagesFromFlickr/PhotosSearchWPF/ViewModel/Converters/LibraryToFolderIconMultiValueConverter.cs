using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PhotosSearchWPF.ViewModel.Converters
{
    public class LibraryToFolderIconMultiValueConverter : IMultiValueConverter
    {
        private static string ExpandedFolderIconPath = @"../Images/Icons/FolderOpen_16x.png";
        private static string ClosedFolderIconPath = @"../Images/Icons/Folder_16x.png";
        private static string FolderWarningIconPath = @"../Images/Icons/FolderWarning_16x.png";

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length > 1 && values[1] == DependencyProperty.UnsetValue)
                return null;

            var isExpanded = (bool)values[0];
            var existsOnDisk = (bool)values[1];
            string uriPath = null;

            if (existsOnDisk)
                uriPath= (isExpanded) ? ExpandedFolderIconPath : ClosedFolderIconPath;
            else
                uriPath = FolderWarningIconPath;

            return new BitmapImage(new Uri(uriPath, UriKind.Relative));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
