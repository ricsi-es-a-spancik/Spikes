using PhotosSearchWPF.Model;
using PhotosSearchWPF.ViewModel.Events;
using Prism.Events;

namespace PhotosSearchWPF.ViewModel
{
    public class ImageLibraryContentViewModel : BindableBase
    {
        private ImageLibraryViewModel _imageLibraryViewModel;
        private readonly IEventAggregator _eventAggregator;

        public ImageLibraryViewModel ImageLibraryViewModel
        {
            get { return _imageLibraryViewModel; }
            set { SetProperty(ref _imageLibraryViewModel, value); }
        }

        public ImageLibraryContentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ImageLibraryDeleted>().Subscribe(OnImageLibraryDeleted);
        }

        private void OnImageLibraryDeleted(Library library)
        {
            if (ImageLibraryViewModel != null && library.Id == ImageLibraryViewModel.Library.Id)
                ImageLibraryViewModel = null;
        }
    }
}
