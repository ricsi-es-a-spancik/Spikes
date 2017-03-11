namespace UITest_SampleApplication.ViewModel
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class OrganizationsViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataContext _dataContext;

        private ObservableCollection<OrganizationViewModel> _organizations;
        private OrganizationViewModel _selectedOrganization;

        public OrganizationsViewModel(IEventAggregator eventAggregator, IDataContext dataContext)
        {
            _eventAggregator = eventAggregator;
            _dataContext = dataContext;

            _eventAggregator.GetEvent<Events.SaveNewOrganizationRequested>().Subscribe(OnSaveNewOrganizationRequested);

            Organizations = new ObservableCollection<OrganizationViewModel>(_dataContext.Organizations.Select(organization => new OrganizationViewModel
                                                                                                                                  {
                                                                                                                                      Name = organization.Name,
                                                                                                                                      DetailsPath = organization.DetailsPath
                                                                                                                                  }));
            OpenNewOrganizationDialog = new DelegateCommand(OnOpenNewOrganizationDialog);
        }

        public ObservableCollection<OrganizationViewModel> Organizations
        {
            get { return _organizations; }
            set { SetProperty(ref _organizations, value); }
        }

        public OrganizationViewModel SelectedOrganization
        {
            get { return _selectedOrganization; }
            set { SetProperty(ref _selectedOrganization, value); }
        }

        public ICommand OpenNewOrganizationDialog { get; private set; }

        private void OnOpenNewOrganizationDialog()
        {
            _eventAggregator.GetEvent<Events.OpenNewOrganizationDialogRequested>().Publish();
        }

        private void OnSaveNewOrganizationRequested(OrganizationViewModel newOrganization)
        {
            if (!string.IsNullOrWhiteSpace(newOrganization.Name) && 
                !string.IsNullOrWhiteSpace(newOrganization.DetailsPath) && 
                File.Exists(newOrganization.DetailsPath))
            {
                var organization = new Organization
                                       {
                                           Name = newOrganization.Name,
                                           DetailsPath = newOrganization.DetailsPath
                                       };

                _dataContext.Organizations.Add(organization);
                Organizations.Add(newOrganization);
                SelectedOrganization = newOrganization;
            }
        }
    }
}