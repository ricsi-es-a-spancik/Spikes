using LocalEntities.ViewModel;
using System.Windows.Controls;

namespace LocalEntities.View
{
    /// <summary>
    /// Interaction logic for LocalItemDetailsView.xaml
    /// </summary>
    public partial class LocalItemDetailsView : UserControl
    {
        public LocalItemDetailsView(LocalItemDetailsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
