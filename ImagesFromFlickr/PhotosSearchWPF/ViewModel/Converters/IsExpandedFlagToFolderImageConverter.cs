using System;
using System.Globalization;
using System.Windows.Data;

namespace PhotosSearchWPF.ViewModel.Converters
{
    public class IsExpandedFlagToFolderImageConverter : IValueConverter
    {
        private static string ExpandedFolderIconPath = @"../Images/Icons/FolderOpen_exp_16x.png";
        private static string ClosedFolderIconPath = @"../Images/Icons/Folder_grey_16x.png";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isExpanded = (bool)value;
            return isExpanded ? ExpandedFolderIconPath : ClosedFolderIconPath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
