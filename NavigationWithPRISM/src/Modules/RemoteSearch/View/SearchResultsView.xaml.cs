using RemoteSearch.ViewModel;
using System.Windows.Controls;

namespace RemoteSearch.View
{
    /// <summary>
    /// Interaction logic for SearchResultsView.xaml
    /// </summary>
    public partial class SearchResultsView : UserControl
    {
        public SearchResultsView(SearchResultsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
