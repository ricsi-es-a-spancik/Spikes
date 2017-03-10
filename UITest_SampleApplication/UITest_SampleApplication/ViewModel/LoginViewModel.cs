namespace UITest_SampleApplication.ViewModel
{
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class LoginViewModel : BindableBase
    {
        private readonly LoginProgressViewModel _loginProgressViewModel;
        private readonly CredentialsFormViewModel _credentialsFormViewModel;

        private BindableBase _currentViewModel;

        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _credentialsFormViewModel = new CredentialsFormViewModel(eventAggregator);
            _loginProgressViewModel = new LoginProgressViewModel(eventAggregator);

            eventAggregator.GetEvent<Events.ValidatingCredentialsRequested>().Subscribe(OnValidatingCredentialsRequested);
            eventAggregator.GetEvent<Events.ReenterCredentialsRequested>().Subscribe(OnReenterCredentialsRequested);
            eventAggregator.GetEvent<Events.SignOutRequested>().Subscribe(OnSignOutRequested);

            CurrentViewModel = _credentialsFormViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private void OnValidatingCredentialsRequested(UserCredentials credentials)
        {
            CurrentViewModel = _loginProgressViewModel;
            _loginProgressViewModel.AuthenticateUser(credentials);
        }

        private void OnReenterCredentialsRequested()
        {
            CurrentViewModel = _credentialsFormViewModel;
        }

        private void OnSignOutRequested()
        {
            CurrentViewModel = _loginProgressViewModel;
            _loginProgressViewModel.SignOutUser();
        }
    }
}
