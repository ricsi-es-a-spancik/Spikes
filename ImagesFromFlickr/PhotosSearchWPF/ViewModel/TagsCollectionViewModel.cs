using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using Prism.Events;
using PhotosSearchWPF.ViewModel.Events;

namespace PhotosSearchWPF.ViewModel
{
    public class TagsCollectionViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private ICollection<string> _tags;

        public ICollection<string> Tags
        {
            get { return _tags; }
            set { SetProperty(ref _tags, value); }
        }

        public ICommand SearchByTag { get; private set; }

        public TagsCollectionViewModel(IEventAggregator eventAggregator, ICollection<string> tags)
        {
            _eventAggregator = eventAggregator;
            Tags = tags;
            SearchByTag = new DelegateCommand<string>(OnSearchByTag);
        }

        private void OnSearchByTag(string tag)
        {
            _eventAggregator.GetEvent<SearchByTagRequested>().Publish(tag);
        }
    }
}