using FlickrNet;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhotosSearchWPF.View
{
    /// <summary>
    /// Interaction logic for FlickrPhotoWrapPanelView.xaml
    /// </summary>
    public partial class FlickrPhotoWrapPanelView : UserControl
    {
        public ObservableCollection<Photo> SearchResults
        {
            get { return (ObservableCollection<Photo>)GetValue(SearchResultsProperty); }
            set { SetValue(SearchResultsProperty, value); }
        }

        public static readonly DependencyProperty SearchResultsProperty =
            DependencyProperty.Register("SearchResults", typeof(ObservableCollection<Photo>), typeof(FlickrPhotoWrapPanelView));

        public ICommand SearchByTagSelectedCommand
        {
            get { return (ICommand)GetValue(SearchByTagSelectedCommandProperty); }
            set { SetValue(SearchByTagSelectedCommandProperty, value); }
        }

        public static readonly DependencyProperty SearchByTagSelectedCommandProperty =
            DependencyProperty.Register("SearchByTagSelectedCommand", typeof(ICommand), typeof(FlickrPhotoWrapPanelView));

        public FlickrPhotoWrapPanelView()
        {
            InitializeComponent();
        }
    }
}
