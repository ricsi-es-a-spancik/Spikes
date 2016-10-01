﻿using FlickrNet;
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

        private TagsCollectionViewModel _tagsCollection;

        public TagsCollectionViewModel TagsCollection
        {
            get { return _tagsCollection; }
            set { SetProperty(ref _tagsCollection, value); }
        }

        public ICommand ShowPhotoDetails { get; private set; }

        public PhotoViewModel(Photo photo)
        {
            Photo = photo;
            TagsCollection = new TagsCollectionViewModel(Photo.Tags);
            TagsCollection.SearchByTagRequested += OnSearchByTagRequested;
            ShowPhotoDetails = new DelegateCommand<PhotoViewModel>(OnShowPhotoDetails);
        }

        public event Action<string> SearchByTagRequested;

        private void OnSearchByTagRequested(string tag)
        {
            SearchByTagRequested?.Invoke(tag);
        }

        public event Action<PhotoViewModel> PhotoDetailsRequested;

        private void OnShowPhotoDetails(PhotoViewModel photoViewModel)
        {
            PhotoDetailsRequested?.Invoke(photoViewModel);
        }
    }
}
