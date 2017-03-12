namespace UITest_SampleApplication.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class VehiclesViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataContext _dataContext;

        private ObservableCollection<VehicleViewModel> _vehicles;

        public VehiclesViewModel(IEventAggregator eventAggregator, IDataContext dataContext)
        {
            _eventAggregator = eventAggregator;
            _dataContext = dataContext;

            _eventAggregator.GetEvent<Events.SaveNewVehicleRequested>().Subscribe(OnSaveNewVehicleRequested);

            Vehicles = new ObservableCollection<VehicleViewModel>(_dataContext.Vehicles.Select(vehicle => new VehicleViewModel
                                                                                                              {
                                                                                                                  Name = vehicle.Name,
                                                                                                                  Organization = vehicle.Organization,
                                                                                                                  Dimensions = vehicle.Dimensions
                                                                                                              }));

            OpenNewVehicleDialog = new DelegateCommand(OnOpenNewVehicleDialog);
        }

        public ObservableCollection<VehicleViewModel> Vehicles
        {
            get { return _vehicles; }
            set { SetProperty(ref _vehicles, value); }
        }

        public ICommand OpenNewVehicleDialog { get; private set; }

        private void OnOpenNewVehicleDialog()
        {
            _eventAggregator.GetEvent<Events.OpenNewVehicleDialogRequested>().Publish();
        }

        private void OnSaveNewVehicleRequested(VehicleViewModel newVehicle)
        {
            if (!string.IsNullOrWhiteSpace(newVehicle.Name) &&
                !string.IsNullOrWhiteSpace(newVehicle.Organization))
            {
                var vehicle = new Vehicle()
                {
                    Name = newVehicle.Name,
                    Organization = newVehicle.Organization,
                    Dimensions = newVehicle.Dimensions
                };

                _dataContext.Vehicles.Add(vehicle);
                Vehicles.Add(newVehicle);
            }
        }
    }
}