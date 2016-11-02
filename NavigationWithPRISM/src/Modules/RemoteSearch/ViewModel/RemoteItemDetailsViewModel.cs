using Business;
using NavigationWithPRISM.Infrastructure;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace RemoteSearch.ViewModel
{
    public class RemoteItemDetailsViewModel : BindableBase, INavigationAware
    {
        IRegionNavigationJournal _navigationJournal;
        private RemoteItem _remoteItem;

        public RemoteItem RemoteItem
        {
            get { return _remoteItem; }
            set { SetProperty(ref _remoteItem, value); }
        }

        public ICommand NavigateBack { get; private set; }

        public RemoteItemDetailsViewModel()
        {
            NavigateBack = new DelegateCommand(OnNavigateBack, () => _navigationJournal?.CanGoBack ?? false);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationJournal = navigationContext.NavigationService.Journal;

            var remoteItemReceived = navigationContext.Parameters["RemoteItem"] as RemoteItem;
            if (remoteItemReceived != null)
            {
                RemoteItem = remoteItemReceived;
            }
        }

        private void OnNavigateBack()
        {
            _navigationJournal.GoBack();
        }
    }
}
