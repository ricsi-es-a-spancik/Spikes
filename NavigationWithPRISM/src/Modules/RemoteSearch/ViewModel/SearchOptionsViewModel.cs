using NavigationWithPRISM.Infrastructure;
using Prism.Commands;
using Prism.Regions;
using RemoteSearch.View;
using System;

namespace RemoteSearch.ViewModel
{
    public class SearchOptionsViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private string _searchCriteria;

        public DelegateCommand SearchCommand { get; private set; }

        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set
            {
                SearchCommand.RaiseCanExecuteChanged();
                SetProperty(ref _searchCriteria, value);
            }
        }

        public SearchOptionsViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SearchCommand = new DelegateCommand(OnSearchCommand, () => !string.IsNullOrWhiteSpace(SearchCriteria));
        }

        private void OnSearchCommand()
        {
            var parameters = new NavigationParameters();
            parameters.Add("SearchCriteria", SearchCriteria);
            var uri = new Uri(typeof(SearchResultsView).FullName, UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, uri, parameters);
        }
    }
}
