using FlickrNet;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Windows.Input;

namespace PhotosSearchWPF.ViewModel
{
    public class PhotoDetailsViewModel : BindableBase
    {
        public ICommand BackToSearchResults { get; private set; }
        public event Action BackToSearchResultsRequested;

        private PhotoViewModel _photoViewModel;

        public PhotoViewModel PhotoViewModel
        {
            get { return _photoViewModel; }
            set { SetProperty(ref _photoViewModel, value); }
        }

        public ICommand OpenInBrowser { get; set; }

        public PhotoDetailsViewModel()
        {
            BackToSearchResults = new DelegateCommand(OnBackToSearchResults);
            OpenInBrowser = new DelegateCommand(OnOpenInBrowser, () => !string.IsNullOrEmpty(PhotoViewModel.Photo.WebUrl));
        }

        private void OnBackToSearchResults()
        {
            BackToSearchResultsRequested?.Invoke();
        }

        private void OnOpenInBrowser()
        {
            System.Diagnostics.Process.Start(PhotoViewModel.Photo.WebUrl);
        }
    }
}
