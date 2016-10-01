using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotosSearchWPF.ViewModel
{
    public class SearchResultsViewModel : BindableBase
    {
        private readonly Flickr _flickr = new Flickr("86d7596ef5548c8a082e8f4c45b47614", "383a46399c655e00");

        private int _pageNumber;

        public int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                SetProperty(ref _pageNumber, value);
                PrevPage.RaiseCanExecuteChanged();
            }
        }

        private string _searchCriteria;

        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set { SetProperty(ref _searchCriteria, value); }
        }

        private string _searchMode;

        public string SearchMode
        {
            get { return _searchMode; }
            set { SetProperty(ref _searchMode, value); }
        }

        private bool _queryInProgress;

        public bool QueryInProgress
        {
            get { return _queryInProgress; }
            set { SetProperty(ref _queryInProgress, value); }
        }

        public PhotoSearchOptions SearchOptions { get; set; }

        public DelegateCommand PrevPage { get; private set; }

        public ICommand NextPage { get; private set; }

        public event Action<PhotoViewModel> PhotoDetailsRequested;

        public event Action<string> SearchByTagRequested;

        public SearchResultsViewModel()
        {
            PrevPage = new DelegateCommand(PrevPageImpl, () => PageNumber > 1);
            NextPage = new DelegateCommand(NextPageImpl);
            QueryInProgress = false;
        }

        private ObservableCollection<PhotoViewModel> _photoSearchResults;

        public ObservableCollection<PhotoViewModel> PhotoSearchResults
        {
            get { return _photoSearchResults; }
            private set { SetProperty(ref _photoSearchResults, value); }
        }

        private void PrevPageImpl()
        {
            --SearchOptions.Page;
            --PageNumber;
            DoSearch();
        }

        private void NextPageImpl()
        {
            ++SearchOptions.Page;
            ++PageNumber;
            DoSearch();
        }

        public void DoSearch()
        {
            PageNumber = SearchOptions.Page;

            if (!string.IsNullOrEmpty(SearchOptions.Text))
            {
                SearchCriteria = SearchOptions.Text;
                SearchMode = "Text";
            }

            else
            {
                SearchCriteria = SearchOptions.Tags;
                SearchMode = "Tags";
            }

            Task.Factory.StartNew(() =>
            {
                QueryInProgress = true;

                var photoViewModels = _flickr.PhotosSearch(SearchOptions).Select(p =>
                {
                    var photoViewModel = new PhotoViewModel(p);
                    photoViewModel.PhotoDetailsRequested += OnShowPhotoDetailsRequested;
                    photoViewModel.SearchByTagRequested += OnSearchByTagRequested;
                    return photoViewModel;
                }).ToList();

                PhotoSearchResults = new ObservableCollection<PhotoViewModel>(photoViewModels);
                QueryInProgress = false;
            });
        }

        private void OnShowPhotoDetailsRequested(PhotoViewModel photoViewModel)
        {
            PhotoDetailsRequested?.Invoke(photoViewModel);
        }

        private void OnSearchByTagRequested(string tag)
        {
            SearchByTagRequested?.Invoke(tag);
        }
    }
}
