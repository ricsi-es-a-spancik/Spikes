namespace UITest_SampleApplication.ViewModel
{
    using System.Windows.Input;

    using Prism.Commands;

    using Prism.Events;

    using UITest_SampleApplication.Model;
    using UITest_SampleApplication.ViewModel.Events;

    public class CredentialsFormViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private UserCredentials _credentials;

        public CredentialsFormViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _credentials = new UserCredentials();
            Login = new DelegateCommand(OnLogin);
        }

        public UserCredentials Credentials
        {
            get { return _credentials; }
            set { SetProperty(ref _credentials, value); }
        }

        public ICommand Login { get; private set; }

        private void OnLogin()
        {
            _eventAggregator.GetEvent<ValidatingCredentialsRequested>().Publish(_credentials);
        }
    }
}
