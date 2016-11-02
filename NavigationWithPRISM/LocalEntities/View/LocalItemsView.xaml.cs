using LocalEntities.ViewModel;
using System.Windows.Controls;

namespace LocalEntities.View
{
    /// <summary>
    /// Interaction logic for LocalItemsView.xaml
    /// </summary>
    public partial class LocalItemsView : UserControl
    {
        public LocalItemsView(LocalItemsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
