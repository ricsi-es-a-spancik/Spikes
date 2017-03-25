namespace UITest_SampleApplication
{
    using System;
    using System.Windows;

    using MahApps.Metro.Controls.Dialogs;

    using Prism.Events;

    using UITest_SampleApplication.Model;
    using UITest_SampleApplication.View;
    using UITest_SampleApplication.View.UserControls;
    using UITest_SampleApplication.ViewModel;

    public partial class App
    {
        private readonly IDataContext _dataContext = new DataContext();
        private readonly IEventAggregator _eventAggregator = new EventAggregator();
        private readonly DialogCoordinator _dialogCoordinator = new DialogCoordinator();

        private readonly MetroDialogSettings _metroDialogSettings = new MetroDialogSettings
                                                                        {
                                                                            AnimateShow = false,
                                                                            AnimateHide = false
                                                                        };

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
            _eventAggregator.GetEvent<Events.OpenNewCharacterDialogRequested>().Subscribe(OnOpenNewCharacterDialogRequested);
            _eventAggregator.GetEvent<Events.OpenNewVehicleDialogRequested>().Subscribe(OnOpenNewVehicleDialogRequested);
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
            _mainViewModel = new MainViewModel(_eventAggregator, _dataContext, credentials.LoginName);
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

        private void OnOpenNewOrganizationDialogRequested()
        {
            _activeDialog = new CustomDialog(_mainView) { Content = new NewOrganizationDialog { DataContext = new NewOrganizationDialogViewModel(_eventAggregator) } };
            _dialogCoordinator.ShowMetroDialogAsync(_mainViewModel, _activeDialog, _metroDialogSettings);
        }

        private void OnOpenNewCharacterDialogRequested()
        {
            _activeDialog = new CustomDialog(_mainView) { Content = new NewCharacterDialog { DataContext = new NewCharacterDialogViewModel(_eventAggregator, _dataContext) } };
            _dialogCoordinator.ShowMetroDialogAsync(_mainViewModel, _activeDialog, _metroDialogSettings);
        }

        private void OnOpenNewVehicleDialogRequested()
        {
            _activeDialog = new CustomDialog(_mainView) { Content = new NewVehicleDialog { DataContext = new NewVehicleDialogViewModel(_eventAggregator, _dataContext) } };
            _dialogCoordinator.ShowMetroDialogAsync(_mainViewModel, _activeDialog, _metroDialogSettings);
        }

        private void OnCloseActiveDialogRequested()
        {
            _dialogCoordinator.HideMetroDialogAsync(_mainViewModel, _activeDialog, _metroDialogSettings);
        }
    }
}
