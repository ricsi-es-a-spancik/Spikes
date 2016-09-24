using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WPFUserControls.ViewModel;

namespace WPFUserControls.View
{
    /// <summary>
    /// Interaction logic for ResourceCollectionUserControl.xaml
    /// </summary>
    public partial class ResourceCollectionUserControl : UserControl
    {
        public static readonly DependencyProperty ResourceCollectionProperty =
            DependencyProperty.Register("ResourceCollection", typeof(ObservableCollection<ResourceViewModel>), typeof(ResourceCollectionUserControl));

        public ObservableCollection<ResourceViewModel> ResourceCollection
        {
            get { return (ObservableCollection<ResourceViewModel>)GetValue(ResourceCollectionProperty); }
            set { SetValue(ResourceCollectionProperty, value); }
        }

        public ResourceCollectionUserControl()
        {
            InitializeComponent();
        }
    }
}
