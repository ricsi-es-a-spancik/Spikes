using PhotosSearchWPF.Model;

namespace PhotosSearchWPF.ViewModel.Events
{
    public class DownloadRequestParameters
    {
        public PhotoViewModel PhotoViewModel { get; set; }

        public Library TargetLibrary { get; set; }
    }
}
