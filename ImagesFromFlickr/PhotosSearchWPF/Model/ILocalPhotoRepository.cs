using FlickrNet;
using System.Threading.Tasks;

namespace PhotosSearchWPF.Model
{
    public interface ILocalPhotoRepository
    {
        Task DownloadPhoto(Photo photo);

        Task<bool> IsLocalCopyExists(Photo photo);
    }
}