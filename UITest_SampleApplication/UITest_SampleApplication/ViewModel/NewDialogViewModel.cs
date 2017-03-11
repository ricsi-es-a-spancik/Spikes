namespace UITest_SampleApplication.ViewModel
{
    using System;
    using System.Linq;
    using System.Windows.Input;

    using Microsoft.Win32;

    using Prism.Commands;
    using Prism.Events;

    public abstract class NewDialogViewModel : BindableBase
    {
        protected readonly IEventAggregator _eventAggregator;

        protected NewDialogViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            Cancel = new DelegateCommand(OnCancel);
        }

        public abstract ICommand Save { get; set; }

        public ICommand Cancel { get; private set; }

        protected string BrowsePath(string dialogFilter)
        {
            var openFileDialog = new OpenFileDialog
                                     {
                                         Multiselect = false,
                                         Filter = dialogFilter,
                                         InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                     };

            return openFileDialog.ShowDialog() != true ? null : openFileDialog.FileNames.Single();
        }

        private void OnCancel()
        {
            _eventAggregator.GetEvent<Events.CloseActiveDialogRequested>().Publish();
        }
    }
}