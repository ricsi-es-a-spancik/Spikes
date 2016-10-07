using System.Collections.Generic;

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

        private List<string> _photoNames;

        public List<string> PhotoNames
        {
            get { return _photoNames; }
            set { SetProperty(ref _photoNames, value); }
        }

        public PhotoLibraryViewModel(string name, List<string> photoNames)
        {
            Name = name;
            PhotoNames = photoNames;
        }
    }
}