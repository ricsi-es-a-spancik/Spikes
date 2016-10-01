using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Windows.Input;
using System;

namespace PhotosSearchWPF.ViewModel
{
    public class TagsCollectionViewModel : BindableBase
    {
        private ICollection<string> _tags;

        public ICollection<string> Tags
        {
            get { return _tags; }
            set { SetProperty(ref _tags, value); }
        }

        public ICommand SearchByTag { get; private set; }

        public TagsCollectionViewModel(ICollection<string> tags)
        {
            Tags = tags;
            SearchByTag = new DelegateCommand<string>(OnSearchByTag);
        }

        public event Action<string> SearchByTagRequested;

        private void OnSearchByTag(string tag)
        {
            SearchByTagRequested?.Invoke(tag);
        }
    }
}