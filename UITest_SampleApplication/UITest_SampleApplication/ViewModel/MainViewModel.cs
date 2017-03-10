namespace UITest_SampleApplication.ViewModel
{
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class MainViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public MainViewModel(IEventAggregator eventAggregator, IDataContext dataContext, string activeUser)
        {
            _eventAggregator = eventAggregator;

            ActiveUser = activeUser;
            SignOut = new DelegateCommand(OnSignOut);

            OrganizationViewModel = new OrganizationViewModel(_eventAggregator, dataContext);
        }

        public string ActiveUser { get; private set; }

        public ICommand SignOut { get; private set; }

        public OrganizationViewModel OrganizationViewModel { get; private set; }

        private void OnSignOut()
        {
            _eventAggregator.GetEvent<Events.SignOutRequested>().Publish();
        }
    }
}
