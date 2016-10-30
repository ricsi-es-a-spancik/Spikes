using NavigationWithPRISM.Infrastructure;
using RemoteSearch.ViewModel;
using System.Windows.Controls;

namespace RemoteSearch.View
{
    /// <summary>
    /// Interaction logic for SearchResultsView.xaml
    /// </summary>
    public partial class SearchResultsView : UserControl, IView<SearchResultsViewModel>
    {
        public SearchResultsView(SearchResultsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public SearchResultsViewModel ViewModel
        {
            get { return (SearchResultsViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
