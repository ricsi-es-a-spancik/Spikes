using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using PhotosSearchWPF.Model;
using PhotosSearchWPF.ViewModel.Events;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PhotosSearchWPF.ViewModel
{
    public class PhotoViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IPhotoLibraryRepository _photoLibraryRepository;
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

        public ICommand DownloadToLibrary { get; private set; }

        private ObservableCollection<string> _libraries;

        public ObservableCollection<string> Libraries
        {
            get { return _libraries; }
        }

        public PhotoViewModel(IEventAggregator eventAggregator, IPhotoLibraryRepository photoLibraryRepository, Photo photo)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<PhotoLibraryAddedEvent>().Subscribe(OnPhotoLibraryAddedEvent);
            _eventAggregator.GetEvent<PhotoLibraryDeletedEvent>().Subscribe(OnPhotoLibraryDeletedEvent);

            _photoLibraryRepository = photoLibraryRepository;
            Photo = photo;

            TagsCollection = new TagsCollectionViewModel(eventAggregator, Photo.Tags);
            ShowPhotoDetails = new DelegateCommand<PhotoViewModel>(OnShowPhotoDetails);
            DownloadToLibrary = new DelegateCommand<string>(OnDownloadToLibrary);

            _libraries = new ObservableCollection<string>(_photoLibraryRepository.GetLibraryNames().Result);
        }

        private void OnPhotoLibraryAddedEvent(string libraryName)
        {
            Libraries.Add(libraryName);
        }

        private void OnPhotoLibraryDeletedEvent(string libraryName)
        {
            Libraries.Remove(libraryName);
        }

        private void OnShowPhotoDetails(PhotoViewModel photoViewModel)
        {
            _eventAggregator.GetEvent<ShowPhotoDetailsRequested>().Publish(photoViewModel);
        }

        private void OnDownloadToLibrary(string library)
        {
            _eventAggregator.GetEvent<DownloadPhotoRequested>().Publish(new DownloadRequestParameters { PhotoViewModel = this, TargetLibrary = library });
        }
    }
}
