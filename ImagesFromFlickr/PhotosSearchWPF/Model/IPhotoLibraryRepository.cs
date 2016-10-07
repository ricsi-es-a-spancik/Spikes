using FlickrNet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotosSearchWPF.Model
{
    public interface IPhotoLibraryRepository
    {
        Task<List<string>> GetLibraryNames();

        Task AddLibrary(string newLibraryName);

        Task<List<string>> GetPhotosOfLibrary(string libraryName);

        Task DownloadPhotoFromUrlToLibrary(Photo photo, string libraryName);
    }
}
