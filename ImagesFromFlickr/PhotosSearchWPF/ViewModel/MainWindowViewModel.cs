using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System;

namespace PhotosSearchWPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string SearchCriteria { get; set; }

        public bool SearchByText { get; set; }

        public bool SearchByTags { get; set; }

        public ICommand Search { get; private set; }

        public int PageNumber { get; private set; }

        public ICommand PrevPage { get; private set; }

        public ICommand NextPage { get; private set; }

        public ICommand ShowPictureByUrl { get; private set; }

        public ICommand InitiateNewSearchByTag { get; private set; }

        public ObservableCollection<Photo> PhotoSearchResults { get; private set; }

        private readonly Flickr _flickr;
        private const int PHOTOS_PER_PAGE = 40;
        private string _currentSearchCriteria;
        private bool _currentSearchByText;

        public MainWindowViewModel()
        {
            _flickr = new Flickr("86d7596ef5548c8a082e8f4c45b47614", "383a46399c655e00");

            SearchByText = true;
            _currentSearchByText = true;
            PageNumber = 0;

            Search = new DelegateCommand(SearchImpl);
            PrevPage = new DelegateCommand(PrevPageImpl);
            NextPage = new DelegateCommand(NextPageImpl);
            ShowPictureByUrl = new DelegateCommand<string>(ShowPictureByUrlImpl);
            InitiateNewSearchByTag = new DelegateCommand<string>(InitiateNewSearchByTagImpl);
        }

        private void SearchImpl()
        {
            if (!string.IsNullOrEmpty(SearchCriteria))
            {
                PageNumber = 1;
                _currentSearchCriteria = SearchCriteria;
                _currentSearchByText = SearchByText;
                DoSearch();
            }
        }

        private void PrevPageImpl()
        {
            if (PageNumber > 1)
            {
                --PageNumber;
                DoSearch();
            }
        }

        private void NextPageImpl()
        {
            ++PageNumber;
            DoSearch();
        }  

        private void DoSearch()
        {
            var options = new PhotoSearchOptions()
            {
                PerPage = PHOTOS_PER_PAGE,
                Page = PageNumber,
                SortOrder = PhotoSearchSortOrder.Relevance,
                Extras = PhotoSearchExtras.Tags | PhotoSearchExtras.ThumbnailUrl
            };

            if (_currentSearchByText)
            {
                options.Text = _currentSearchCriteria;
            }
            else
            {
                options.Tags = _currentSearchCriteria;
            }

            PhotoSearchResults = new ObservableCollection<Photo>(_flickr.PhotosSearch(options));
            NotifyPropertyChanged(nameof(PageNumber));
            NotifyPropertyChanged(nameof(PhotoSearchResults));
        }

        private void ShowPictureByUrlImpl(string url)
        {
            MessageBox.Show(url);
        }

        private void InitiateNewSearchByTagImpl(string tag)
        {
            SearchByTags = true;
            SearchByText = false;
            SearchCriteria = tag;
            NotifyPropertyChanged(nameof(SearchByTags));
            NotifyPropertyChanged(nameof(SearchByText));
            NotifyPropertyChanged(nameof(SearchCriteria));
            SearchImpl();
        }
    }
}
