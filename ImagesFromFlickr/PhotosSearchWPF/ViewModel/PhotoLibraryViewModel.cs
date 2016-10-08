using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhotosSearchWPF.ViewModel
{
    public class PhotoLibraryViewModel : BindableBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private ObservableCollection<string> _photoNames;

        public ObservableCollection<string> PhotoNames
        {
            get { return _photoNames; }
            set { SetProperty(ref _photoNames, value); }
        }

        private bool _isExpanded;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }

        public PhotoLibraryViewModel(string name, List<string> photoNames)
            : this(name, photoNames, true)
        {
        }

        public PhotoLibraryViewModel(string name, List<string> photoNames, bool isExpanded)
        {
            Name = name;
            PhotoNames = new ObservableCollection<string>(photoNames);
            IsExpanded = isExpanded;
        }
    }
}