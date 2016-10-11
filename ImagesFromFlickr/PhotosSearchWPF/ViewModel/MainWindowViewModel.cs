using FlickrNet;
using Microsoft.Practices.Unity;
using PhotosSearchWPF.Model;
using PhotosSearchWPF.Services;
using PhotosSearchWPF.ViewModel.Events;
using Prism.Events;

namespace PhotosSearchWPF.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private IUnityContainer _container;

        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public SearchOptionsViewModel SearchOptionsViewModel { get; private set; }

        public LibrariesViewModel LibrariesViewModel { get; private set; }

        private SearchResultsViewModel _searchResultsViewModel;
        private PhotoDetailsViewModel _photoDetailsViewModel;

        public MainWindowViewModel()
        {
            SetUpContainer();

            SearchOptionsViewModel = _container.Resolve<SearchOptionsViewModel>();
            LibrariesViewModel = _container.Resolve<LibrariesViewModel>();
            _searchResultsViewModel = _container.Resolve<SearchResultsViewModel>();
            _photoDetailsViewModel = _container.Resolve<PhotoDetailsViewModel>();
        }

        private void SetUpContainer()
        {
            _container = new UnityContainer();

            _container.RegisterType<IFileSystem, FileSystem>();
            _container.RegisterType<IWebClient, WebClient>();
            _container.RegisterType<IImageLibraryRepository, ImageLibraryRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ILibraryManager, LibraryManager>();

            var eventAggregator = new EventAggregator();
            eventAggregator.GetEvent<PhotoSearchRequested>().Subscribe(OnPhotoSearchRequested, ThreadOption.UIThread);
            eventAggregator.GetEvent<ShowPhotoDetailsRequested>().Subscribe(OnPhotoDetailsRequested, ThreadOption.UIThread);
            eventAggregator.GetEvent<SearchByTagRequested>().Subscribe(OnSearchByTagRequested, ThreadOption.UIThread);
            eventAggregator.GetEvent<NavigateBackToSearchResultsRequested>().Subscribe(OnNavigateBackToSearchResultsRequested, ThreadOption.UIThread);

            _container.RegisterInstance<IEventAggregator>(eventAggregator);
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
