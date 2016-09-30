using PhotosSearchWPF.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PhotosSearchWPF.View
{
    /// <summary>
    /// Interaction logic for FlickrPhotoWrapPanelView.xaml
    /// </summary>
    public partial class FlickrPhotoWrapPanelView : UserControl
    {
        public ObservableCollection<PhotoViewModel> SearchResults
        {
            get { return (ObservableCollection<PhotoViewModel>)GetValue(SearchResultsProperty); }
            set { SetValue(SearchResultsProperty, value); }
        }

        public static readonly DependencyProperty SearchResultsProperty =
            DependencyProperty.Register("SearchResults", typeof(ObservableCollection<PhotoViewModel>), typeof(FlickrPhotoWrapPanelView));

        public FlickrPhotoWrapPanelView()
        {
            InitializeComponent();
        }
    }
}
