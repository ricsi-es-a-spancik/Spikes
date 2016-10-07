using Microsoft.Practices.Prism.Commands;
using Prism.Events;
using PhotosSearchWPF.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PhotosSearchWPF.ViewModel.Events;
using System;

namespace PhotosSearchWPF.ViewModel
{
    public class LibrariesViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private IPhotoLibraryRepository _photoLibraryRepository;

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

        public ObservableCollection<PhotoLibraryViewModel> _photoLibraryViewModels;

        public ObservableCollection<PhotoLibraryViewModel> PhotoLibraryViewModels
        {
            get { return _photoLibraryViewModels; }
            set { SetProperty(ref _photoLibraryViewModels, value); }
        }

        public LibrariesViewModel(IEventAggregator eventAggregator, IPhotoLibraryRepository photoLibraryRepository)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<DownloadPhotoRequested>().Subscribe(OnDownloadPhotoRequested);

            _photoLibraryRepository = photoLibraryRepository;

            CreateNewLibrary = new DelegateCommand(OnCreateNewLibrary, () => !string.IsNullOrEmpty(NewLibraryName));

            RefreshLibraries();
        }

        private async void OnCreateNewLibrary()
        {
            await _photoLibraryRepository.AddLibrary(NewLibraryName);
            NewLibraryName = string.Empty;
            RefreshLibraries();
        }

        private async void RefreshLibraries()
        {
            var newLibraries = (await _photoLibraryRepository.GetLibraryNames()).Select(async name =>
                new PhotoLibraryViewModel(name, await _photoLibraryRepository.GetPhotosOfLibrary(name)));

            PhotoLibraryViewModels = new ObservableCollection<PhotoLibraryViewModel>(await Task.WhenAll(newLibraries));
        }

        private async void OnDownloadPhotoRequested(DownloadRequestParameters parameters)
        {
            await _photoLibraryRepository.DownloadPhotoFromUrlToLibrary(parameters.PhotoViewModel.Photo, parameters.TargetLibrary);
            RefreshLibraries();
        }
    }
}
