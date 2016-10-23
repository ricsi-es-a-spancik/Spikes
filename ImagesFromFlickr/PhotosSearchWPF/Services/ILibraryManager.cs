using PhotosSearchWPF.Model;
using System.Collections.Generic;

namespace PhotosSearchWPF.Services
{
    public interface ILibraryManager
    {
        List<Library> GetLibraries();

        Library AddLibrary(Library library);

        Library RemoveImageFromLibrary(Image image);

        void RemoveLibrary(Library library);

        Image DownloadImageToLibrary(string imageUrl, string flickrPhotoId, string imageFileName, Library library);

        bool IsLibraryExistsWithName(string libraryName);
    }
}
