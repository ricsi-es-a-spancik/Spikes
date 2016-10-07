namespace PhotosSearchWPF.ViewModel.Events
{
    public class DownloadRequestParameters
    {
        public PhotoViewModel PhotoViewModel { get; set; }

        public string TargetLibrary { get; set; }
    }
}
