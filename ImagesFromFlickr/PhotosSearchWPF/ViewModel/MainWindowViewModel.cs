﻿using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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

        public ObservableCollection<Photo> SearchResults { get; private set; }

        private readonly Flickr _flickr;
        private const int PHOTOS_PER_PAGE = 20;
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
            PhotoSearchOptions options;

            if (_currentSearchByText)
            {
                options = new PhotoSearchOptions
                {
                    Text = _currentSearchCriteria,
                    PerPage = PHOTOS_PER_PAGE,
                    Page = PageNumber,
                    SortOrder = PhotoSearchSortOrder.Relevance,
                    Extras = PhotoSearchExtras.ThumbnailUrl
                };
            }
            else
            {
                options = new PhotoSearchOptions
                {
                    Tags = _currentSearchCriteria,
                    PerPage = PHOTOS_PER_PAGE,
                    Page = PageNumber,
                    SortOrder = PhotoSearchSortOrder.Relevance,
                    Extras = PhotoSearchExtras.ThumbnailUrl | PhotoSearchExtras.Tags
                };
            }

            SearchResults = new ObservableCollection<Photo>(_flickr.PhotosSearch(options));
            NotifyPropertyChanged(nameof(PageNumber));
            NotifyPropertyChanged(nameof(SearchResults));
        }

        private void ShowPictureByUrlImpl(string url)
        {
            MessageBox.Show(url);
        }
    }
}
