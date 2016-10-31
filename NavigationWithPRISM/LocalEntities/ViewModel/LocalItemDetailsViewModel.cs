using NavigationWithPRISM.Infrastructure;
using Prism.Regions;
using Business;

namespace LocalEntities.ViewModel
{
    public class LocalItemDetailsViewModel : BindableBase, INavigationAware
    {
        private LocalItem _localItem;

        public LocalItem LocalItem
        {
            get { return _localItem; }
            set { SetProperty(ref _localItem, value); }
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
            var localItemReceived = navigationContext.Parameters["LocalItem"] as LocalItem;
            if (localItemReceived != null)
            {
                LocalItem = localItemReceived;
            }
        }
    }
}
