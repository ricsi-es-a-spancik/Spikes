namespace UITest_SampleApplication.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class NewCharacterDialogViewModel : NewDialogViewModel
    {
        public NewCharacterDialogViewModel(IEventAggregator eventAggregator, IDataContext dataContext)
            : base(eventAggregator)
        {
            NewCharacter = new CharacterViewModel();
            Organizations = new ReadOnlyObservableCollection<OrganizationViewModel>(new ObservableCollection<OrganizationViewModel>(dataContext.Organizations.Select(org => org.ToViewModel())));

            BrowseAvatarPath = new DelegateCommand(OnBrowseAvatarPath);
            Save = new DelegateCommand(OnSaveNewCharacter);
        }

        public CharacterViewModel NewCharacter { get; }

        public ReadOnlyObservableCollection<OrganizationViewModel> Organizations { get; private set; }

        public ICommand BrowseAvatarPath { get; private set; }

        public sealed override ICommand Save { get; set; }

        private void OnBrowseAvatarPath()
        {
            NewCharacter.AvatarPath = BrowsePath("Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png");
        }

        private void OnSaveNewCharacter()
        {
            _eventAggregator.GetEvent<Events.SaveNewCharacterRequested>().Publish(NewCharacter);
            _eventAggregator.GetEvent<Events.CloseActiveDialogRequested>().Publish();
        }
    }
}