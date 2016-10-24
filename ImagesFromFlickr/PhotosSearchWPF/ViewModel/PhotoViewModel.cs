using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using PhotosSearchWPF.Model;
using PhotosSearchWPF.Services;
using PhotosSearchWPF.ViewModel.Events;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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

        private ObservableCollection<LibraryTarget> _libraries;

        public ObservableCollection<LibraryTarget> Libraries
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
            DownloadToLibrary = new DelegateCommand<LibraryTarget>(OnDownloadToLibrary);

            var libraryTargets = _libraryManager.GetLibraries().Select(lib =>
            {
                var hasLocalCopyOfPhoto = lib.Images.Any(img => img.ExistsOnDisk && img.FlickrPhotoId == Photo.PhotoId);
                return new LibraryTarget { Library = lib, HasLocalCopy = hasLocalCopyOfPhoto };
            });

            _libraries = new ObservableCollection<LibraryTarget>(libraryTargets);
        }

        private void OnAddImageLibraryRequested(Library library)
        {
            Libraries.Add(new LibraryTarget { Library = library, HasLocalCopy = false });
        }

        private void OnDeleteImageLibraryRequested(Library library)
        {
            Libraries.Remove(Libraries.First(target => target.Library.Id == library.Id));
            _eventAggregator.GetEvent<ImageLibraryDeleted>().Publish(library);
        }

        private void OnShowPhotoDetails(PhotoViewModel photoViewModel)
        {
            _eventAggregator.GetEvent<ShowPhotoDetailsRequested>().Publish(photoViewModel);
        }

        private void OnDownloadToLibrary(LibraryTarget libraryTarget)
        {
            if (!libraryTarget.Library.ExistsOnDisk)
            {
                MessageBox.Show($"Library {libraryTarget.Library.Name} does not exist on disk.", "Error");
                return;
            }
            else if (libraryTarget.HasLocalCopy)
            {
                MessageBox.Show($"Library {libraryTarget.Library.Name} does already contain a photo with id {Photo.PhotoId}.", "Error");
                return;
            }

            _eventAggregator.GetEvent<DownloadPhotoRequested>().Publish(new DownloadRequestParameters { PhotoViewModel = this, LibraryTarget = libraryTarget });
        }
    }
}
