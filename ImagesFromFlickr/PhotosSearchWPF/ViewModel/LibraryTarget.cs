using PhotosSearchWPF.Model;

namespace PhotosSearchWPF.ViewModel
{
    public class LibraryTarget : BindableBase
    {
        private Library _library;

        public Library Library
        {
            get { return _library; }
            set { SetProperty(ref _library, value); }
        }

        private bool _hasLocalCopy;

        public bool HasLocalCopy
        {
            get { return _hasLocalCopy; }
            set { SetProperty(ref _hasLocalCopy, value); }
        }
    }
}
