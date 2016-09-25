using FlickrNet;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PhotosSearchWPF.View
{
    /// <summary>
    /// Interaction logic for FlickrPhotoListBoxView.xaml
    /// </summary>
    public partial class FlickrPhotoListBoxView : UserControl
    {
        public ObservableCollection<Photo> SearchResults
        {
            get { return (ObservableCollection<Photo>)GetValue(SearchResultsProperty); }
            set { SetValue(SearchResultsProperty, value); }
        }

        public static readonly DependencyProperty SearchResultsProperty =
            DependencyProperty.Register("SearchResults", typeof(ObservableCollection<Photo>), typeof(FlickrPhotoListBoxView));

        public FlickrPhotoListBoxView()
        {
            InitializeComponent();
        }
    }
}
