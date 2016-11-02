using NavigationWithPRISM.Infrastructure;
using Prism.Regions;
using Business;
using System.Windows.Input;
using Prism.Commands;

namespace LocalEntities.ViewModel
{
    public class LocalItemDetailsViewModel : BindableBase, INavigationAware
    {
        IRegionNavigationJournal _navigationJournal;
        private LocalItem _localItem;

        public LocalItem LocalItem
        {
            get { return _localItem; }
            set { SetProperty(ref _localItem, value); }
        }

        public ICommand NavigateBack { get; private set; }

        public LocalItemDetailsViewModel()
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

            var localItemReceived = navigationContext.Parameters["LocalItem"] as LocalItem;
            if (localItemReceived != null)
            {
                LocalItem = localItemReceived;
            }
        }

        private void OnNavigateBack()
        {
            _navigationJournal.GoBack();
        }
    }
}
