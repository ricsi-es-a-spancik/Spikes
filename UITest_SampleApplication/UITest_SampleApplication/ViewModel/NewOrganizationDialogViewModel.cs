namespace UITest_SampleApplication.ViewModel
{
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Events;

    public class NewOrganizationDialogViewModel : NewDialogViewModel
    {
        public NewOrganizationDialogViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            NewOrganization = new OrganizationViewModel();

            BrowseDetailsPath = new DelegateCommand(OnBrowseDetailsPath);
            Save = new DelegateCommand(OnSaveNewOrganization);
        }

        public OrganizationViewModel NewOrganization { get; }

        public ICommand BrowseDetailsPath { get; private set; }

        public sealed override ICommand Save { get; set; }

        private void OnBrowseDetailsPath()
        {
            NewOrganization.DetailsPath = BrowsePath("Rtf files (*.rtf)|*.rtf");
        }

        private void OnSaveNewOrganization()
        {
            _eventAggregator.GetEvent<Events.SaveNewOrganizationRequested>().Publish(NewOrganization);
            _eventAggregator.GetEvent<Events.CloseActiveDialogRequested>().Publish();
        }
    }
}
