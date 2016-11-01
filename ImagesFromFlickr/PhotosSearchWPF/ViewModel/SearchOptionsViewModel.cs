using Microsoft.Practices.Prism.Commands;
using FlickrNet;
using Prism.Events;
using PhotosSearchWPF.ViewModel.Events;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;

namespace PhotosSearchWPF.ViewModel
{
    public class SearchOptionsViewModel : BindableBase
    {
        private const int PHOTOS_PER_PAGE = 20;
        private IEventAggregator _eventAggregator;
        private HashSet<Style> _stylesIncluded = new HashSet<Style>();

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

        public ObservableCollection<Style> Styles { get; private set; }

        public DelegateCommand Search { get; private set; }

        public ICommand AddStyle { get; private set; }

        public SearchOptionsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            SearchByText = true;
            Styles = new ObservableCollection<Style>(Enum.GetValues(typeof(Style)).Cast<Style>());
            Search = new DelegateCommand(OnSearch, () => !string.IsNullOrEmpty(SearchCriteria));
            AddStyle = new DelegateCommand<Style?>(OnAddStyle);
        }

        private void OnSearch()
        {
            var options = new PhotoSearchOptions()
            {
                PerPage = PHOTOS_PER_PAGE,
                Page = 1,
                SortOrder = PhotoSearchSortOrder.Relevance,
                Styles = _stylesIncluded,
                Extras = PhotoSearchExtras.All
            };

            if (SearchByText)
                options.Text = SearchCriteria;
            else
                options.Tags = SearchCriteria;

            _eventAggregator.GetEvent<PhotoSearchRequested>().Publish(options);
        }

        private void OnAddStyle(Style? style)
        {
            if (!style.HasValue)
                return;

            if (_stylesIncluded.Contains(style.Value))
                _stylesIncluded.Remove(style.Value);
            else
                _stylesIncluded.Add(style.Value);
        }
    }
}
