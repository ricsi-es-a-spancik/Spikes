using FlickrNet;

namespace PhotosSearchWPF.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public SearchOptionsViewModel SearchOptionsViewModel { get; private set; }

        private SearchResultsViewModel _searchResultsViewModel = new SearchResultsViewModel();
        private PhotoDetailsViewModel _photoDetailsViewModel = new PhotoDetailsViewModel();

        public MainWindowViewModel()
        {
            SearchOptionsViewModel = new SearchOptionsViewModel();
            SearchOptionsViewModel.PhotoSearchRequested += OnPhotoSearchRequested;

            _searchResultsViewModel.PhotoDetailsRequested += OnPhotoDetailsRequested;
            _searchResultsViewModel.SearchByTagRequested += OnSearchByTagRequested;

            _photoDetailsViewModel.BackToSearchResultsRequested += OnBackToSearchResultsRequested;
        }

        private void OnSearchByTagRequested(string tag)
        {
            SearchOptionsViewModel.SearchCriteria = tag;
            SearchOptionsViewModel.SearchByText = false;
            SearchOptionsViewModel.SearchByTags = true;
            SearchOptionsViewModel.Search.Execute();
        }

        private void OnPhotoDetailsRequested(PhotoViewModel photoViewModel)
        {
            _photoDetailsViewModel.PhotoViewModel = photoViewModel;
            CurrentViewModel = _photoDetailsViewModel;
        }

        private void OnBackToSearchResultsRequested()
        {
            CurrentViewModel = _searchResultsViewModel;
        }

        private void OnPhotoSearchRequested(PhotoSearchOptions options)
        {
            _searchResultsViewModel.SearchOptions = options;
            CurrentViewModel = _searchResultsViewModel;
            _searchResultsViewModel.DoSearch();
        }
    }
}
