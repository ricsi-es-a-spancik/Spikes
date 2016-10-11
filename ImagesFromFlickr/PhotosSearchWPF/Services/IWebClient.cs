namespace PhotosSearchWPF.Services
{
    public interface IWebClient
    {
        void DownloadFile(string address, string filePath);
    }
}
