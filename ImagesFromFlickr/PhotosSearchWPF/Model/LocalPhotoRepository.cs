using System.Threading.Tasks;
using FlickrNet;
using System.IO;
using System.Net;

namespace PhotosSearchWPF.Model
{
    public class LocalPhotoRepository : ILocalPhotoRepository
    {
        private const string LIBRARY_PATH = @"Library";

        public async Task DownloadPhoto(Photo photo)
        {
            var download = Task.Factory.StartNew(() =>
            {
                if (!Directory.Exists(LIBRARY_PATH))
                    Directory.CreateDirectory(LIBRARY_PATH);

                var localPhotoPath = Path.Combine(LIBRARY_PATH, $"{photo.PhotoId}.jpg");

                if (!File.Exists(localPhotoPath))
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(photo.SmallUrl, localPhotoPath);
                    }
                }
            });

            await download;
        }

        public async Task<bool> IsLocalCopyExists(Photo photo)
        {
            var searchLocalCopy = Task.Factory.StartNew(() =>
            {
                var localPhotoPath = Path.Combine(LIBRARY_PATH, $"{photo.PhotoId}.jpg");
                return File.Exists(localPhotoPath);
            });

            return await searchLocalCopy;
        }
    }
}