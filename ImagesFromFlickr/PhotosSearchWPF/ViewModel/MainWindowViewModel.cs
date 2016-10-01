using FlickrNet;
using PhotosSearchWPF.ViewModel.Events;
using Prism.Events;

namespace PhotosSearchWPF.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;

        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public SearchOptionsViewModel SearchOptionsViewModel { get; private set; }

        private SearchResultsViewModel _searchResultsViewModel;
        private PhotoDetailsViewModel _photoDetailsViewModel;

        public MainWindowViewModel()
        {
            _eventAggregator = new EventAggregator();
            _eventAggregator.GetEvent<PhotoSearchRequested>().Subscribe(OnPhotoSearchRequested, ThreadOption.UIThread);
            _eventAggregator.GetEvent<ShowPhotoDetailsRequested>().Subscribe(OnPhotoDetailsRequested, ThreadOption.UIThread);
            _eventAggregator.GetEvent<SearchByTagRequested>().Subscribe(OnSearchByTagRequested, ThreadOption.UIThread);   
            _eventAggregator.GetEvent<NavigateBackToSearchResultsRequested>().Subscribe(OnNavigateBackToSearchResultsRequested, ThreadOption.UIThread);
            SearchOptionsViewModel = new SearchOptionsViewModel(_eventAggregator);

            _searchResultsViewModel = new SearchResultsViewModel(_eventAggregator);

            _photoDetailsViewModel = new PhotoDetailsViewModel(_eventAggregator);
        }

        private void OnPhotoSearchRequested(PhotoSearchOptions options)
        {
            _searchResultsViewModel.SearchOptions = options;
            CurrentViewModel = _searchResultsViewModel;
            _searchResultsViewModel.DoSearch();
        }

        private void OnPhotoDetailsRequested(PhotoViewModel photoViewModel)
        {
            _photoDetailsViewModel.PhotoViewModel = photoViewModel;
            CurrentViewModel = _photoDetailsViewModel;
        }

        private void OnSearchByTagRequested(string tag)
        {
            SearchOptionsViewModel.SearchCriteria = tag;
            SearchOptionsViewModel.SearchByText = false;
            SearchOptionsViewModel.SearchByTags = true;
            SearchOptionsViewModel.Search.Execute();
        }

        private void OnNavigateBackToSearchResultsRequested()
        {
            CurrentViewModel = _searchResultsViewModel;
        } 
    }
}
