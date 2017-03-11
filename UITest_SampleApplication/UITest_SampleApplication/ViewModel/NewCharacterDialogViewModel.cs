namespace UITest_SampleApplication.ViewModel
{
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    public class NewCharacterDialogViewModel : NewDialogViewModel
    {
        public NewCharacterDialogViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            NewCharacter = new CharacterViewModel();

            BrowseAvatarPath = new DelegateCommand(OnBrowseAvatarPath);
            Save = new DelegateCommand(OnSaveNewCharacter);
        }

        public CharacterViewModel NewCharacter { get; }

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