namespace UITest_SampleApplication.ViewModel
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class LoginProgressViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private bool _isAuthenticationInProgress;
        private bool _isAuthenticationFailed;

        public LoginProgressViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            IsAuthenticationInProgress = false;

            CancelLogin = new DelegateCommand(OnCancelLogin);
            ReenterCredentials = new DelegateCommand(OnReenterCredentials);
        }

        public bool IsAuthenticationInProgress
        {
            get { return _isAuthenticationInProgress; }
            set { SetProperty(ref _isAuthenticationInProgress, value); }
        }

        public bool IsAuthenticationFailed
        {
            get { return _isAuthenticationFailed; }
            set { SetProperty(ref _isAuthenticationFailed, value); }
        }

        public ICommand CancelLogin { get; private set; }

        public ICommand ReenterCredentials { get; private set; }

        public async void AuthenticateUser(UserCredentials credentials)
        {
            IsAuthenticationInProgress = true;
            IsAuthenticationFailed = false;

            await Task.Delay(TimeSpan.FromSeconds(3));

            if (string.IsNullOrWhiteSpace(credentials.LoginName))
            {
                IsAuthenticationInProgress = false;
                IsAuthenticationFailed = true;
            }
            else
            {
                _eventAggregator.GetEvent<Events.LoginRequested>().Publish(credentials);
            }
        }

        public async void SignOutUser()
        {
            IsAuthenticationInProgress = true;

            await Task.Delay(TimeSpan.FromSeconds(3));

            _eventAggregator.GetEvent<Events.ReenterCredentialsRequested>().Publish();
        }

        private void OnCancelLogin()
        {
            _eventAggregator.GetEvent<Events.CancelLoginRequested>().Publish();
        }

        private void OnReenterCredentials()
        {
            _eventAggregator.GetEvent<Events.ReenterCredentialsRequested>().Publish();
        }
    }
}