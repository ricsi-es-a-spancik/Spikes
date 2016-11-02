using RemoteSearch.ViewModel;
using System.Windows.Controls;

namespace RemoteSearch.View
{
    /// <summary>
    /// Interaction logic for SearchOptionsView.xaml
    /// </summary>
    public partial class SearchOptionsView : UserControl
    {
        public SearchOptionsView(SearchOptionsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
