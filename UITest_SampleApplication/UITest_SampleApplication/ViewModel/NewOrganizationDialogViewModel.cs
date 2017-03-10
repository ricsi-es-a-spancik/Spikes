namespace UITest_SampleApplication.ViewModel
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Input;

    using Microsoft.Win32;

    using Prism.Commands;
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class NewOrganizationDialogViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private string _name;
        private string _detailsPath;

        public NewOrganizationDialogViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            BrowseDetailsPath = new DelegateCommand(OnBrowseDetailsPath);
            Save = new DelegateCommand(OnSaveNewOrganization);
            Cancel = new DelegateCommand(OnCancelNewOrganization);
        }

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

        public ICommand BrowseDetailsPath { get; private set; }

        public ICommand Save { get; private set; }

        public ICommand Cancel { get; private set; }

        private void OnBrowseDetailsPath()
        {
            var openFileDialog = new OpenFileDialog
                                     {
                                         Multiselect = false,
                                         Filter = "Rtf files (*.rtf)|*.rtf",
                                         InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                     };

            if (openFileDialog.ShowDialog() != true)
                return;

            DetailsPath = openFileDialog.FileNames.Single();
        }

        private void OnSaveNewOrganization()
        {
            var newOrganization = new Organization { Name = Name, DetailsPath = DetailsPath };

            _eventAggregator.GetEvent<Events.SaveNewOrganizationRequested>().Publish(newOrganization);
            _eventAggregator.GetEvent<Events.CloseActiveDialogRequested>().Publish();
        }

        private void OnCancelNewOrganization()
        {
            _eventAggregator.GetEvent<Events.CloseActiveDialogRequested>().Publish();
        }
    }
}
