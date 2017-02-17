using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using Microsoft.Practices.Prism.PubSubEvents;
using UITest_SampleApplication.Model;
using UITest_SampleApplication.ViewModel.Events;

namespace UITest_SampleApplication.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;

        private UserCredentials _credentials;

        public LoginViewModel(IEventAggregator eventAggregator)
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
            _eventAggregator.GetEvent<LoginRequested>().Publish(_credentials);
        }
    }
}
