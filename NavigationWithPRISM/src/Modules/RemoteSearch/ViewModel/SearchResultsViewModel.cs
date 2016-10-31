using Business;
using NavigationWithPRISM.Infrastructure;
using NavigationWithPRISM.Infrastructure.ServiceInterfaces;
using Prism.Commands;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using RemoteSearch.View;
using Prism.Events;
using NavigationWithPRISM.Infrastructure.Events;

namespace RemoteSearch.ViewModel
{
    public class SearchResultsViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IRemoteSearchService _remoteSearchService;

        private string _searchCriteriaReceived;

        public string SearchCriteriaReceived
        {
            get { return _searchCriteriaReceived; }
            set { SetProperty(ref _searchCriteriaReceived, value); }
        }

        private ObservableCollection<RemoteItem> _searchResults;
        
        public ObservableCollection<RemoteItem> SearchResults
        {
            get { return _searchResults; }
            set { SetProperty(ref _searchResults, value); }
        }

        public ICommand SeeRemoteItemDetails { get; private set; }

        public ICommand DownloadRemoteItem { get; private set; }

        public SearchResultsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IRemoteSearchService remoteSearchService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _remoteSearchService = remoteSearchService;

            SeeRemoteItemDetails = new DelegateCommand<RemoteItem>(OnSeeRemoteItemDetails);
            DownloadRemoteItem = new DelegateCommand<RemoteItem>(OnDownloadRemoteItem);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var searchCriteriaReceived = navigationContext.Parameters["SearchCriteria"] as string;
            if (!string.IsNullOrWhiteSpace(searchCriteriaReceived))
            {
                SearchCriteriaReceived = searchCriteriaReceived;
                SearchResults = new ObservableCollection<RemoteItem>(await _remoteSearchService.Search(SearchCriteriaReceived));
            }
        }

        private void OnSeeRemoteItemDetails(RemoteItem remoteItem)
        {
            var parameters = new NavigationParameters();
            parameters.Add("RemoteItem", remoteItem);
            var uri = new Uri(typeof(RemoteItemDetailsView).FullName, UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, uri, parameters);
        }

        private void OnDownloadRemoteItem(RemoteItem remoteItem)
        {
            _eventAggregator.GetEvent<DownloadRemoteItemRequested>().Publish(remoteItem);
        }
    }
}
