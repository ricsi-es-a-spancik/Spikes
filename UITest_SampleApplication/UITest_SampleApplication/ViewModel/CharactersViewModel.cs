namespace UITest_SampleApplication.ViewModel
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class CharactersViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataContext _dataContext;

        private ObservableCollection<CharacterViewModel> _characters;
        private CharacterViewModel _selectedCharacter;

        public CharactersViewModel(IEventAggregator eventAggregator, IDataContext dataContext)
        {
            _eventAggregator = eventAggregator;
            _dataContext = dataContext;

            _eventAggregator.GetEvent<Events.SaveNewCharacterRequested>().Subscribe(OnSaveNewCharacterRequested);

            Characters = new ObservableCollection<CharacterViewModel>(_dataContext.Characters.Select(character => character.ToViewModel()));

            OpenNewCharacterDialog = new DelegateCommand(OnOpenNewCharacterDialog);
            OpenCharacterDetails = new DelegateCommand<CharacterViewModel>(OnOpenCharacterDetails);
        }

        public ObservableCollection<CharacterViewModel> Characters
        {
            get { return _characters; }
            set { SetProperty(ref _characters, value); }
        }

        public CharacterViewModel SelectedCharacter
        {
            get { return _selectedCharacter; }
            set { SetProperty(ref _selectedCharacter, value); }
        }

        public ICommand OpenNewCharacterDialog { get; private set; }

        public ICommand OpenCharacterDetails { get; private set; }

        private void OnOpenNewCharacterDialog()
        {
            _eventAggregator.GetEvent<Events.OpenNewCharacterDialogRequested>().Publish();
        }

        private void OnOpenCharacterDetails(CharacterViewModel character)
        {
            SelectedCharacter = character;
            _eventAggregator.GetEvent<Events.OpenCharacterDetailsFlyoutRequested>().Publish();
        }

        private void OnSaveNewCharacterRequested(CharacterViewModel newCharacter)
        {
            if (!string.IsNullOrWhiteSpace(newCharacter.Name) && 
                newCharacter.Organization != null &&
                !string.IsNullOrWhiteSpace(newCharacter.Details) && 
                File.Exists(newCharacter.AvatarPath))
            {
                _dataContext.Characters.Add(newCharacter.ToModel(_dataContext));
                Characters.Add(newCharacter);
            }
        }
    }
}