namespace UITest_SampleApplication.ViewModel
{
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.ViewModel.Events;

    public class MainViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;

        public MainViewModel(IEventAggregator eventAggregator, string activeUser)
        {
            _eventAggregator = eventAggregator;

            ActiveUser = activeUser;
            SignOut = new DelegateCommand(OnSignOut);
        }

        public string ActiveUser { get; private set; }

        public ICommand SignOut { get; private set; }

        private void OnSignOut()
        {
            _eventAggregator.GetEvent<SignOutRequested>().Publish();
        }
    }
}
