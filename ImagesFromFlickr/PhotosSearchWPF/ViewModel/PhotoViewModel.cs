using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Windows.Input;

namespace PhotosSearchWPF.ViewModel
{
    public class PhotoViewModel : BindableBase
    {
        private Photo _photo;

        public Photo Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }

        public ICommand ShowPhotoDetails { get; private set; }

        public PhotoViewModel()
        {
            ShowPhotoDetails = new DelegateCommand<PhotoViewModel>(OnShowPhotoDetails);
        }

        public event Action<PhotoViewModel> PhotoDetailsRequested;

        private void OnShowPhotoDetails(PhotoViewModel photoViewModel)
        {
            PhotoDetailsRequested?.Invoke(photoViewModel);
        }
    }
}
