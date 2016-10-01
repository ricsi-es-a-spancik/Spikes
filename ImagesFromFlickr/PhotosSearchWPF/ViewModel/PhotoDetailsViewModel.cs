using Microsoft.Practices.Prism.Commands;
using PhotosSearchWPF.ViewModel.Events;
using Prism.Events;
using System.Windows.Input;

namespace PhotosSearchWPF.ViewModel
{
    public class PhotoDetailsViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private PhotoViewModel _photoViewModel;

        public PhotoViewModel PhotoViewModel
        {
            get { return _photoViewModel; }
            set { SetProperty(ref _photoViewModel, value); }
        }

        public ICommand OpenInBrowser { get; set; }

        public ICommand BackToSearchResults { get; private set; }

        public PhotoDetailsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            BackToSearchResults = new DelegateCommand(OnBackToSearchResults);
            OpenInBrowser = new DelegateCommand(OnOpenInBrowser, () => !string.IsNullOrEmpty(PhotoViewModel.Photo.WebUrl));
        }

        private void OnBackToSearchResults()
        {
            _eventAggregator.GetEvent<NavigateBackToSearchResultsRequested>().Publish();
        }

        private void OnOpenInBrowser()
        {
            System.Diagnostics.Process.Start(PhotoViewModel.Photo.WebUrl);
        }
    }
}
