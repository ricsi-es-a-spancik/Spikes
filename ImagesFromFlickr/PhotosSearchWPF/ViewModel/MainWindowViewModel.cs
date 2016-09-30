using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Windows.Input;

namespace PhotosSearchWPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand ShowPictureByUrl { get; private set; }

        public ICommand InitiateNewSearchByTag { get; private set; }

        public SearchOptionsViewModel SearchOptionsViewModel { get; private set; }

        public BindableBase CurrentViewModel { get; private set; }

        private SearchResultsViewModel _searchResultsViewModel = new SearchResultsViewModel();
        private PhotoDetailsViewModel _photoDetailsViewModel = new PhotoDetailsViewModel();

        public MainWindowViewModel()
        {
            SearchOptionsViewModel = new SearchOptionsViewModel();
            SearchOptionsViewModel.PhotoSearchRequested += OnPhotoSearchRequested;

            _searchResultsViewModel.PhotoDetailsRequested += OnPhotoDetailsRequested;
            _photoDetailsViewModel.BackToSearchResultsRequested += OnBackToSearchResultsRequested;
            
            ShowPictureByUrl = new DelegateCommand<string>(ShowPictureByUrlImpl);
            InitiateNewSearchByTag = new DelegateCommand<string>(InitiateNewSearchByTagImpl);
        }

        private void OnPhotoDetailsRequested(PhotoViewModel photoViewModel)
        {
            _photoDetailsViewModel.Photo = photoViewModel.Photo;
            CurrentViewModel = _photoDetailsViewModel;
            NotifyPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnBackToSearchResultsRequested()
        {
            CurrentViewModel = _searchResultsViewModel;
            NotifyPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnPhotoSearchRequested(PhotoSearchOptions options)
        {
            _searchResultsViewModel.SearchOptions = options;
            CurrentViewModel = _searchResultsViewModel;
            NotifyPropertyChanged(nameof(CurrentViewModel));
            _searchResultsViewModel.DoSearch();
        }

        private void ShowPictureByUrlImpl(string url)
        {
            MessageBox.Show(url);
        }

        private void InitiateNewSearchByTagImpl(string tag)
        {
            //SearchByTags = true;
            //SearchByText = false;
            //SearchCriteria = tag;
            //NotifyPropertyChanged(nameof(SearchByTags));
            //NotifyPropertyChanged(nameof(SearchByText));
            //NotifyPropertyChanged(nameof(SearchCriteria));
            //SearchImpl();
        }
    }
}
