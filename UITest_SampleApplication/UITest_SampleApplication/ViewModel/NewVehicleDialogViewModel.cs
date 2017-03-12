namespace UITest_SampleApplication.ViewModel
{
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    public class NewVehicleDialogViewModel : NewDialogViewModel
    {
        public NewVehicleDialogViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            NewVehicle = new VehicleViewModel();

            Save = new DelegateCommand(OnSaveNewVehicle);
        }

        public VehicleViewModel NewVehicle { get; }

        public override ICommand Save { get; set; }

        private void OnSaveNewVehicle()
        {
            _eventAggregator.GetEvent<Events.SaveNewVehicleRequested>().Publish(NewVehicle);
            _eventAggregator.GetEvent<Events.CloseActiveDialogRequested>().Publish();
        }
    }
}