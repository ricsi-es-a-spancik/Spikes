namespace UITest_SampleApplication.ViewModel
{
    public class OrganizationViewModel : BindableBase
    {
        private string _name;
        private string _detailsPath;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string DetailsPath
        {
            get { return _detailsPath; }
            set { SetProperty(ref _detailsPath, value); }
        }
    }
}