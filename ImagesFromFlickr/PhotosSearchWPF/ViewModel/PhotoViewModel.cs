using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using PhotosSearchWPF.ViewModel.Events;
using Prism.Events;
using System;
using System.Windows.Input;

namespace PhotosSearchWPF.ViewModel
{
    public class PhotoViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private Photo _photo;

        public Photo Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }

        private TagsCollectionViewModel _tagsCollection;

        public TagsCollectionViewModel TagsCollection
        {
            get { return _tagsCollection; }
            set { SetProperty(ref _tagsCollection, value); }
        }

        private bool _isLocalCopyExists;

        public bool IsLocalCopyExists
        {
            get { return _isLocalCopyExists; }
            set { SetProperty(ref _isLocalCopyExists, value); }
        }

        public ICommand ShowPhotoDetails { get; private set; }

        public ICommand DownloadPhoto { get; private set; }

        public PhotoViewModel(IEventAggregator eventAggregator, Photo photo)
        {
            _eventAggregator = eventAggregator;
            Photo = photo;
            TagsCollection = new TagsCollectionViewModel(eventAggregator, Photo.Tags);
            ShowPhotoDetails = new DelegateCommand<PhotoViewModel>(OnShowPhotoDetails);
            DownloadPhoto = new DelegateCommand<PhotoViewModel>(OnDownloadPhoto);
        }

        private void OnShowPhotoDetails(PhotoViewModel photoViewModel)
        {
            _eventAggregator.GetEvent<ShowPhotoDetailsRequested>().Publish(photoViewModel);
        }

        private void OnDownloadPhoto(PhotoViewModel photoViewModel)
        {
            _eventAggregator.GetEvent<DownloadPhotoRequested>().Publish(photoViewModel);
        }
    }
}
