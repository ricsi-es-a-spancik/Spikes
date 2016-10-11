namespace PhotosSearchWPF.Services
{
    public class WebClient : IWebClient
    {
        public void DownloadFile(string address, string filePath)
        {
            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile(address, filePath);
            }
        }
    }
}
