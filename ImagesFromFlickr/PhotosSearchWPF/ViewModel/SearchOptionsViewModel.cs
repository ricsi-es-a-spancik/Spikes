using Microsoft.Practices.Prism.Commands;
using System;
using FlickrNet;
using Prism.Events;
using PhotosSearchWPF.ViewModel.Events;

namespace PhotosSearchWPF.ViewModel
{
    public class SearchOptionsViewModel : BindableBase
    {
        private const int PHOTOS_PER_PAGE = 20;
        private IEventAggregator _eventAggregator;

        private string _searchCriteria;

        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set
            {
                SetProperty(ref _searchCriteria, value);
                Search.RaiseCanExecuteChanged();
            }
        }

        private bool _searchByText;

        public bool SearchByText
        {
            get { return _searchByText; }
            set { SetProperty(ref _searchByText, value); }
        }

        private bool _searchByTags;

        public bool SearchByTags
        {
            get { return _searchByTags; }
            set { SetProperty(ref _searchByTags, value); }
        }

        public DelegateCommand Search { get; private set; }

        public SearchOptionsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SearchByText = true;
            Search = new DelegateCommand(OnSearch, () => !string.IsNullOrEmpty(SearchCriteria));
        }

        private void OnSearch()
        {
            var options = new PhotoSearchOptions()
            {
                PerPage = PHOTOS_PER_PAGE,
                Page = 1,
                SortOrder = PhotoSearchSortOrder.Relevance,
                Extras = PhotoSearchExtras.All
            };

            if (SearchByText)
                options.Text = SearchCriteria;
            else
                options.Tags = SearchCriteria;

            _eventAggregator.GetEvent<PhotoSearchRequested>().Publish(options);
        }
    }
}
