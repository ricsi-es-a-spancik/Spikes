namespace UITest_SampleApplication.ViewModel
{
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class MainViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private bool _characterDetailsFlyoutIsOpen;

        public MainViewModel(IEventAggregator eventAggregator, IDataContext dataContext, string activeUser)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<Events.OpenCharacterDetailsFlyoutRequested>().Subscribe(OnOpenCharacterDetailsFlyoutRequested);

            ActiveUser = activeUser;
            SignOut = new DelegateCommand(OnSignOut);

            OrganizationsViewModel = new OrganizationsViewModel(_eventAggregator, dataContext);
            CharactersViewModel = new CharactersViewModel(_eventAggregator, dataContext);
            VehiclesViewModel = new VehiclesViewModel(_eventAggregator, dataContext);
        }

        public string ActiveUser { get; private set; }

        public ICommand SignOut { get; private set; }

        public OrganizationsViewModel OrganizationsViewModel { get; private set; }

        public CharactersViewModel CharactersViewModel { get; private set; }

        public VehiclesViewModel VehiclesViewModel { get; private set; }

        public bool CharacterDetailsFlyoutIsOpen
        {
            get { return _characterDetailsFlyoutIsOpen; }
            set { SetProperty(ref _characterDetailsFlyoutIsOpen, value); }
        }

        private void OnSignOut()
        {
            _eventAggregator.GetEvent<Events.SignOutRequested>().Publish();
        }

        private void OnOpenCharacterDetailsFlyoutRequested()
        {
            CharacterDetailsFlyoutIsOpen = true;
        }
    }
}
