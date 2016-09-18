using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace PhotosSearchWPF.ViewModel
{
    public class TagsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tagsBuilder = new StringBuilder();
            tagsBuilder.Append("Tags: ");

            if (value != null)
            {
                var tagsCollection = value as Collection<string>;
                var joinedTags = (tagsCollection != null && tagsCollection.Count != 0) ? string.Join(", ", tagsCollection) : "-";
                tagsBuilder.Append(joinedTags);
            }

            return tagsBuilder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
