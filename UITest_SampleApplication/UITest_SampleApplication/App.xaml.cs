namespace UITest_SampleApplication
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    using MahApps.Metro.Controls.Dialogs;

    using Prism.Events;

    using UITest_SampleApplication.Model;
    using UITest_SampleApplication.View;
    using UITest_SampleApplication.View.UserControls;
    using UITest_SampleApplication.ViewModel;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public partial class App
    {
        private readonly IEventAggregator _eventAggregator = new EventAggregator();
        private readonly DialogCoordinator _dialogCoordinator = new DialogCoordinator();

        private LoginWindow _loginView;
        private MainWindow _mainView;
        private MainViewModel _mainViewModel;
        private CustomDialog _activeDialog;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _eventAggregator.GetEvent<Events.LoginRequested>().Subscribe(OnLoginRequested);
            _eventAggregator.GetEvent<Events.CancelLoginRequested>().Subscribe(OnCancelLoginRequested);
            _eventAggregator.GetEvent<Events.SignOutRequested>().Subscribe(OnSignOutRequested);
            _eventAggregator.GetEvent<Events.OpenNewOrganizationDialogRequested>().Subscribe(OnOpenNewOrganizationDialogRequested);
            _eventAggregator.GetEvent<Events.CloseActiveDialogRequested>().Subscribe(OnCloseActiveDialogRequested);

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
            _mainViewModel = new MainViewModel(_eventAggregator, new DataContext(), credentials.LoginName);
            _mainView = new MainWindow { DataContext = _mainViewModel };
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

        private void OnCloseActiveDialogRequested()
        {
            _dialogCoordinator.HideMetroDialogAsync(_mainViewModel, _activeDialog);
        }

        private void OnOpenNewOrganizationDialogRequested()
        {
            _activeDialog = new CustomDialog(_mainView) { Content = new NewOrganizationDialog { DataContext = new NewOrganizationDialogViewModel(_eventAggregator) } };
            _dialogCoordinator.ShowMetroDialogAsync(_mainViewModel, _activeDialog);
        }
    }
}
