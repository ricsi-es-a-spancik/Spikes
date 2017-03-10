namespace UITest_SampleApplication.ViewModel
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class OrganizationViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataContext _dataContext;

        private ObservableCollection<Organization> _organizations;
        private Organization _selectedOrganization;

        public OrganizationViewModel(IEventAggregator eventAggregator, IDataContext dataContext)
        {
            _eventAggregator = eventAggregator;
            _dataContext = dataContext;

            _eventAggregator.GetEvent<Events.SaveNewOrganizationRequested>().Subscribe(OnSaveNewOrganizationRequested);

            Organizations = new ObservableCollection<Organization>(_dataContext.Organizations);
            OpenNewOrganizationDialog = new DelegateCommand(OnOpenNewOrganizationDialog);
        }

        public ObservableCollection<Organization> Organizations
        {
            get { return _organizations; }
            set { SetProperty(ref _organizations, value); }
        }

        public Organization SelectedOrganization
        {
            get { return _selectedOrganization; }
            set { SetProperty(ref _selectedOrganization, value); }
        }

        public ICommand OpenNewOrganizationDialog { get; private set; }

        private void OnOpenNewOrganizationDialog()
        {
            _eventAggregator.GetEvent<Events.OpenNewOrganizationDialogRequested>().Publish();
        }

        private void OnSaveNewOrganizationRequested(Organization organization)
        {
            if (!string.IsNullOrWhiteSpace(organization.Name) && !string.IsNullOrWhiteSpace(organization.DetailsPath) && File.Exists(organization.DetailsPath))
            {
                _dataContext.Organizations.Add(organization);
                Organizations = new ObservableCollection<Organization>(_dataContext.Organizations);
                SelectedOrganization = organization;
            }
        }
    }
}