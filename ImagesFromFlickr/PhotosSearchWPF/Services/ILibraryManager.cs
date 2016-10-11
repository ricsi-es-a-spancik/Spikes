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

        Image DownloadImageToLibrary(string imageUrl, string imageFileName, Library library);
    }
}
