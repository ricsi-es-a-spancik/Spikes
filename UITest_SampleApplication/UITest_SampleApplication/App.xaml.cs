namespace UITest_SampleApplication
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    using Prism.Events;

    using UITest_SampleApplication.Model;
    using UITest_SampleApplication.View;
    using UITest_SampleApplication.ViewModel;
    using UITest_SampleApplication.ViewModel.Events;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public partial class App
    {
        private readonly IEventAggregator _eventAggregator = new EventAggregator();

        private LoginWindow _loginView;
        private MainWindow _mainView;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _eventAggregator.GetEvent<LoginRequested>().Subscribe(OnLoginRequested);
            _eventAggregator.GetEvent<CancelLoginRequested>().Subscribe(OnCancelLoginRequested);
            _eventAggregator.GetEvent<SignOutRequested>().Subscribe(OnSignOutRequested);

            var loginViewModel = new LoginViewModel(_eventAggregator);
            _loginView = new LoginWindow { DataContext = loginViewModel };
            _loginView.Closed += OnApplicationWindowClosed;

            _loginView.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            OnApplicationWindowClosed(null, EventArgs.Empty);
        }

        private void OnLoginRequested(UserCredentials credentials)
        {
            var mainViewModel = new MainViewModel(_eventAggregator, credentials.LoginName);
            _mainView = new MainWindow { DataContext = mainViewModel };
            _mainView.Closed += OnApplicationWindowClosed;

            _mainView.Show();
            _loginView.Hide();
        }

        private void OnCancelLoginRequested()
        {
            Shutdown();
        }

        private void OnSignOutRequested()
        {
            _loginView.Show();
            _mainView.Hide();
        }

        private void OnApplicationWindowClosed(object sender, EventArgs e)
        {
            _loginView.Close();
            _mainView?.Close();
        }
    }
}
