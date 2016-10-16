using Microsoft.Practices.Prism.Commands;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using PhotosSearchWPF.ViewModel.Events;
using System.Windows.Input;
using System.Collections.Generic;
using PhotosSearchWPF.Services;
using PhotosSearchWPF.Model;
using System.IO;

namespace PhotosSearchWPF.ViewModel
{
    public class LibrariesViewModel : BindableBase
    {
        private const string LIBRARIES_FOLDER_PATH = "Libraries";

        private IEventAggregator _eventAggregator;
        private ILibraryManager _libraryManager;

        private string _newLibraryName;

        public string NewLibraryName
        {
            get { return _newLibraryName; }
            set
            {
                SetProperty(ref _newLibraryName, value);
                CreateNewLibrary.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand CreateNewLibrary { get; private set; }

        public ICommand RefreshLibraries { get; private set; }

        public ICommand ExpandAll { get; private set; }

        public ICommand CollapseAll { get; private set; }

        public ICommand DeleteLibrary { get; private set; }

        public ICommand DeleteImage { get; private set; }

        public ObservableCollection<ImageLibraryViewModel> _photoLibraryViewModels;

        public ObservableCollection<ImageLibraryViewModel> PhotoLibraryViewModels
        {
            get { return _photoLibraryViewModels; }
            set { SetProperty(ref _photoLibraryViewModels, value); }
        }

        public LibrariesViewModel(IEventAggregator eventAggregator, ILibraryManager libraryManager)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<DownloadPhotoRequested>().Subscribe(OnDownloadPhotoRequested);

            _libraryManager = libraryManager;

            CreateNewLibrary = new DelegateCommand(OnCreateNewLibrary, () => !string.IsNullOrEmpty(NewLibraryName));
            RefreshLibraries = new DelegateCommand(RefreshLibrariesImpl);
            ExpandAll = new DelegateCommand(OnExpandAll);
            CollapseAll = new DelegateCommand(OnCollapseAll);
            DeleteLibrary = new DelegateCommand<ImageLibraryViewModel>(OnDeleteLibrary);
            DeleteImage = new DelegateCommand<Image>(OnDeleteImage);

            PhotoLibraryViewModels = new ObservableCollection<ImageLibraryViewModel>();
            RefreshLibrariesImpl();
        }

        private void OnCreateNewLibrary()
        {
            var newLibrary = new Library
            {
                DirectoryPath = Path.Combine(LIBRARIES_FOLDER_PATH, NewLibraryName),
                Name = NewLibraryName,
                Images = new List<Image>()
            };

             var libraryAdded = _libraryManager.AddLibrary(newLibrary);

            PhotoLibraryViewModels.Add(new ImageLibraryViewModel(libraryAdded));
            _eventAggregator.GetEvent<AddImageLibraryRequested>().Publish(libraryAdded);
            NewLibraryName = string.Empty;
        }

        private void RefreshLibrariesImpl()
        {
            var newLibraries = (_libraryManager.GetLibraries()).Select(lib => new ImageLibraryViewModel(lib));
            PhotoLibraryViewModels.Clear();
            PhotoLibraryViewModels.AddRange(newLibraries);
        }

        private void OnDownloadPhotoRequested(DownloadRequestParameters parameters)
        {
            var imageAdded = _libraryManager.DownloadImageToLibrary(parameters.PhotoViewModel.Photo.SmallUrl, $"{parameters.PhotoViewModel.Photo.PhotoId}.jpg", parameters.TargetLibrary);
            var vm = PhotoLibraryViewModels.First(libvm => libvm.Library.Name == parameters.TargetLibrary.Name);
            vm.Images.Add(imageAdded);
        }

        private void OnExpandAll()
        {
            foreach (var vm in PhotoLibraryViewModels)
                vm.IsExpanded = true;
        }

        private void OnCollapseAll()
        {
            foreach (var vm in PhotoLibraryViewModels)
                vm.IsExpanded = false;
        }

        private void OnDeleteLibrary(ImageLibraryViewModel photoLibraryViewModel)
        {
            _libraryManager.RemoveLibrary(photoLibraryViewModel.Library);
            PhotoLibraryViewModels.Remove(photoLibraryViewModel);
            _eventAggregator.GetEvent<DeleteImageLibraryRequested>().Publish(photoLibraryViewModel.Library);
        }

        private void OnDeleteImage(Image image)
        {
            _libraryManager.RemoveImageFromLibrary(image);
            var libraryVM = PhotoLibraryViewModels.First(vm => vm.Library.Name == image.Library.Name);
            libraryVM.Images.Remove(image);
        }
    }
}
