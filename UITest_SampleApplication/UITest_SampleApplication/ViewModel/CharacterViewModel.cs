namespace UITest_SampleApplication.ViewModel
{
    public class CharacterViewModel : BindableBase
    {
        private string _name;
        private string _organization;
        private string _details;
        private string _avatarPath;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Organization
        {
            get { return _organization; }
            set { SetProperty(ref _organization, value); }
        }

        public string Details
        {
            get { return _details; }
            set { SetProperty(ref _details, value); }
        }

        public string AvatarPath
        {
            get { return _avatarPath; }
            set { SetProperty(ref _avatarPath, value); }
        }
    }
}
