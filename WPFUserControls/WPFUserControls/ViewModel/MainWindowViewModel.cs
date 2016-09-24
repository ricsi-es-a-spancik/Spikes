using System.Collections.ObjectModel;

namespace WPFUserControls.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string MainLabel { get; set; }

        public int MainValue { get; set; }

        public ObservableCollection<ResourceViewModel> Resources { get; set; }

        public MainWindowViewModel()
        {
            MainLabel = "MainLabel";
            MainValue = 1024;

            Resources = new ObservableCollection<ResourceViewModel>
            {
                new ResourceViewModel { StringField = "String of first", IntField = 1, BoolField = true },
                new ResourceViewModel { StringField = "String of second", IntField = 2, BoolField = false },
                new ResourceViewModel { StringField = "String of third", IntField = 3, BoolField = false }
            };
        }
    }
}
