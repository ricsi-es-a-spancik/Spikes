using PhotosSearchWPF.Model;
using System.Collections.Generic;

namespace PhotosSearchWPF.Services
{
    public interface IImageLibraryRepository
    {
        List<Library> GetLibrariesWithoutImages();

        Library AddLibrary(Library library);

        void RemoveLibrary(int libraryId);

        List<Image> GetImagesOfLibrary(int libraryId);

        Image AddImageToLibrary(Image image);

        Library RemoveImageFromLibrary(int libraryId, int imageId);
    }
}
