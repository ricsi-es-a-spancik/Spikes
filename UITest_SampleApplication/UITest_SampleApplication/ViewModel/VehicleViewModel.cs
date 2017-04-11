namespace UITest_SampleApplication.ViewModel
{
    public class VehicleViewModel : BindableBase
    {
        private string _name;
        private OrganizationViewModel _organization;
        private double _dimensions;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public OrganizationViewModel Organization
        {
            get { return _organization; }
            set { SetProperty(ref _organization, value); }
        }

        public double Dimensions
        {
            get { return _dimensions; }
            set { SetProperty(ref _dimensions, value); }
        }
    }
}