using NavigationWithPRISM.Infrastructure;
using Prism.Regions;

namespace RemoteSearch.ViewModel
{
    public class SearchResultsViewModel : BindableBase, INavigationAware
    {
        private string _searchCriteriaReceived;

        public string SearchCriteriaReceived
        {
            get { return _searchCriteriaReceived; }
            set { SetProperty(ref _searchCriteriaReceived, value); }
        }

        public SearchResultsViewModel()
        {

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
            var searchCriteriaReceived = navigationContext.Parameters["SearchCriteria"] as string;
            if (!string.IsNullOrWhiteSpace(searchCriteriaReceived))
                SearchCriteriaReceived = searchCriteriaReceived;
        }
    }
}
