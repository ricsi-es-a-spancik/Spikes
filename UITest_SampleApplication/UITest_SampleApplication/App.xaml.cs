using Microsoft.Practices.Prism.PubSubEvents;
using System.Windows;
using UITest_SampleApplication.View;
using UITest_SampleApplication.ViewModel;
using UITest_SampleApplication.ViewModel.Events;
using UITest_SampleApplication.Model;

namespace UITest_SampleApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IEventAggregator _eventAggregator = new EventAggregator();
        private LoginWindow _loginView;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _eventAggregator.GetEvent<LoginRequested>().Subscribe(OnLoginRequested);

            var loginViewModel = new LoginViewModel(_eventAggregator);
            _loginView = new LoginWindow { DataContext = loginViewModel };

            _loginView.Show();
        }

        private void OnLoginRequested(UserCredentials credentials)
        {
            if (string.IsNullOrWhiteSpace(credentials.LoginName))
            {
                MessageBox.Show("You must provide a valid login name!", "Error");
                return;
            }
                
            var mainViewModel = new MainViewModel(_eventAggregator, credentials.LoginName);
            var mainView = new MainWindow { DataContext = mainViewModel };

            mainView.Show();
            _loginView.Close();
        }
    }
}
