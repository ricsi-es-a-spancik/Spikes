using RemoteSearch.ViewModel;
using System.Windows.Controls;

namespace RemoteSearch.View
{
    /// <summary>
    /// Interaction logic for RemoteItemDetailsView.xaml
    /// </summary>
    public partial class RemoteItemDetailsView : UserControl
    {
        public RemoteItemDetailsView(RemoteItemDetailsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
