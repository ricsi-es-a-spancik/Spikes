using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using PhotosSearchWPF.Model;
using PhotosSearchWPF.Services;
using PhotosSearchWPF.ViewModel.Events;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PhotosSearchWPF.ViewModel
{
    public class PhotoViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ILibraryManager _libraryManager;
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

        private ObservableCollection<Library> _libraries;

        public ObservableCollection<Library> Libraries
        {
            get { return _libraries; }
        }

        public PhotoViewModel(IEventAggregator eventAggregator, ILibraryManager libraryManager, Photo photo)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AddImageLibraryRequested>().Subscribe(OnAddImageLibraryRequested);
            _eventAggregator.GetEvent<DeleteImageLibraryRequested>().Subscribe(OnDeleteImageLibraryRequested);

            _libraryManager = libraryManager;
            Photo = photo;

            TagsCollection = new TagsCollectionViewModel(eventAggregator, Photo.Tags);
            ShowPhotoDetails = new DelegateCommand<PhotoViewModel>(OnShowPhotoDetails);
            DownloadToLibrary = new DelegateCommand<Library>(OnDownloadToLibrary);

            _libraries = new ObservableCollection<Library>(_libraryManager.GetLibraries());
        }

        private void OnAddImageLibraryRequested(Library library)
        {
            Libraries.Add(library);
        }

        private void OnDeleteImageLibraryRequested(Library library)
        {
            Libraries.Remove(library);
        }

        private void OnShowPhotoDetails(PhotoViewModel photoViewModel)
        {
            _eventAggregator.GetEvent<ShowPhotoDetailsRequested>().Publish(photoViewModel);
        }

        private void OnDownloadToLibrary(Library library)
        {
            _eventAggregator.GetEvent<DownloadPhotoRequested>().Publish(new DownloadRequestParameters { PhotoViewModel = this, TargetLibrary = library });
        }
    }
}
