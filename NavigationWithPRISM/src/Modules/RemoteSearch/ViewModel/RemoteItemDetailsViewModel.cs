using Business;
using NavigationWithPRISM.Infrastructure;
using Prism.Regions;

namespace RemoteSearch.ViewModel
{
    public class RemoteItemDetailsViewModel : BindableBase, INavigationAware
    {
        private RemoteItem _remoteItem;

        public RemoteItem RemoteItem
        {
            get { return _remoteItem; }
            set { SetProperty(ref _remoteItem, value); }
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
            var remoteItemReceived = navigationContext.Parameters["RemoteItem"] as RemoteItem;
            if (remoteItemReceived != null)
            {
                RemoteItem = remoteItemReceived;
            }
        }
    }
}
