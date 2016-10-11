using PhotosSearchWPF.Model;
using System.Collections.ObjectModel;

namespace PhotosSearchWPF.ViewModel
{
    public class ImageLibraryViewModel : BindableBase
    {
        public Library Library { get; }

        private ObservableCollection<Image> _images;

        public ObservableCollection<Image> Images
        {
            get { return _images; }
            set { SetProperty(ref _images, value); }
        }

        private bool _isExpanded;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }

        public ImageLibraryViewModel(Library library)
            : this(library, false)
        {
        }

        public ImageLibraryViewModel(Library library, bool isExpanded)
        {
            Library = library;
            Images = new ObservableCollection<Image>(Library.Images);
            IsExpanded = isExpanded;
        }
    }
}