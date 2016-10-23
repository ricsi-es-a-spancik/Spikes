using PhotosSearchWPF.Model;

namespace PhotosSearchWPF.ViewModel.Events
{
    public class DownloadRequestParameters
    {
        public PhotoViewModel PhotoViewModel { get; set; }

        public LibraryTarget LibraryTarget { get; set; }
    }
}
