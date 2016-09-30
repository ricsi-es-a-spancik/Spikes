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

        private Photo _photo;

        public Photo Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }

        public ICommand OpenInBrowser { get; set; }

        public PhotoDetailsViewModel()
        {
            BackToSearchResults = new DelegateCommand(OnBackToSearchResults);
            OpenInBrowser = new DelegateCommand(OnOpenInBrowser, () => !string.IsNullOrEmpty(Photo.WebUrl));
        }

        private void OnBackToSearchResults()
        {
            BackToSearchResultsRequested?.Invoke();
        }

        private void OnOpenInBrowser()
        {
            System.Diagnostics.Process.Start(Photo.WebUrl);
        }
    }
}
