using Microsoft.Practices.Prism.PubSubEvents;

namespace UITest_SampleApplication.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;

        public MainViewModel(IEventAggregator eventAggregator, string activeUser)
        {
            _eventAggregator = eventAggregator;
            ActiveUser = activeUser;
        }

        public string ActiveUser { get; private set; }
    }
}
