using NavigationWithPRISM.Infrastructure;
using RemoteSearch.ViewModel;
using System.Windows.Controls;

namespace RemoteSearch.View
{
    /// <summary>
    /// Interaction logic for SearchOptionsView.xaml
    /// </summary>
    public partial class SearchOptionsView : UserControl, IView<SearchOptionsViewModel>
    {
        public SearchOptionsView(SearchOptionsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public SearchOptionsViewModel ViewModel
        {
            get { return (SearchOptionsViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
