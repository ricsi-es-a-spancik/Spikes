using Microsoft.Practices.Prism.Commands;
using Prism.Events;
using PhotosSearchWPF.Model;
using System.Collections.ObjectModel;
using System.Linq;
using PhotosSearchWPF.ViewModel.Events;
using System.Windows.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public ICommand RefreshLibraries { get; private set; }

        public ICommand ExpandAll { get; private set; }

        public ICommand CollapseAll { get; private set; }

        public ICommand DeleteLibrary { get; private set; }

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
            RefreshLibraries = new DelegateCommand(RefreshLibrariesImpl);
            ExpandAll = new DelegateCommand(OnExpandAll);
            CollapseAll = new DelegateCommand(OnCollapseAll);
            DeleteLibrary = new DelegateCommand<PhotoLibraryViewModel>(OnDeleteLibrary);

            RefreshLibrariesImpl();
        }

        private async void OnCreateNewLibrary()
        {
            await _photoLibraryRepository.AddLibrary(NewLibraryName);
            PhotoLibraryViewModels.Add(new PhotoLibraryViewModel(NewLibraryName, new List<string>()));
            _eventAggregator.GetEvent<PhotoLibraryAddedEvent>().Publish(NewLibraryName);
            NewLibraryName = string.Empty;
        }

        private async void RefreshLibrariesImpl()
        {
            var newLibraries = (await _photoLibraryRepository.GetLibraryNames()).Select(async name =>
                new PhotoLibraryViewModel(name, await _photoLibraryRepository.GetPhotosOfLibrary(name)));

            PhotoLibraryViewModels = new ObservableCollection<PhotoLibraryViewModel>(await Task.WhenAll(newLibraries));
        }

        private async void OnDownloadPhotoRequested(DownloadRequestParameters parameters)
        {
            await _photoLibraryRepository.DownloadPhotoFromUrlToLibrary(parameters.PhotoViewModel.Photo, parameters.TargetLibrary);
            var photoViewModel = PhotoLibraryViewModels.FirstOrDefault(vm => vm.Name == parameters.TargetLibrary);
            photoViewModel?.PhotoNames?.Add(parameters.PhotoViewModel.Photo.PhotoId);
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

        private async void OnDeleteLibrary(PhotoLibraryViewModel photoLibraryViewModel)
        {
            await _photoLibraryRepository.DeleteLibrary(photoLibraryViewModel.Name);
            PhotoLibraryViewModels.Remove(photoLibraryViewModel);
            _eventAggregator.GetEvent<PhotoLibraryDeletedEvent>().Publish(photoLibraryViewModel.Name);
        }
    }
}
