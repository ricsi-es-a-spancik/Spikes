namespace UITest_SampleApplication.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class NewVehicleDialogViewModel : NewDialogViewModel
    {
        public NewVehicleDialogViewModel(IEventAggregator eventAggregator, IDataContext dataContext)
            : base(eventAggregator)
        {
            NewVehicle = new VehicleViewModel();
            Organizations = new ReadOnlyObservableCollection<OrganizationViewModel>(new ObservableCollection<OrganizationViewModel>(dataContext.Organizations.Select(org => org.ToViewModel())));

            Save = new DelegateCommand(OnSaveNewVehicle);
        }

        public VehicleViewModel NewVehicle { get; }

        public ReadOnlyObservableCollection<OrganizationViewModel> Organizations { get; private set; }

        public sealed override ICommand Save { get; set; }

        private void OnSaveNewVehicle()
        {
            _eventAggregator.GetEvent<Events.SaveNewVehicleRequested>().Publish(NewVehicle);
            _eventAggregator.GetEvent<Events.CloseActiveDialogRequested>().Publish();
        }
    }
}