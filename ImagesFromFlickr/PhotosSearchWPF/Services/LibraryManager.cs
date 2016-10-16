using System.Collections.Generic;
using PhotosSearchWPF.Model;
using System.Linq;
using System.IO;

namespace PhotosSearchWPF.Services
{
    public class LibraryManager : ILibraryManager
    {
        private readonly IFileSystem _fileSystem;
        private readonly IImageLibraryRepository _imageLibraryRepository;
        private readonly IWebClient _webClient;

        public LibraryManager(IFileSystem fileSystem, IImageLibraryRepository imageLibraryRepository, IWebClient webClient)
        {
            _fileSystem = fileSystem;
            _imageLibraryRepository = imageLibraryRepository;
            _webClient = webClient;
        }

        public Library AddLibrary(Library library)
        {
            _fileSystem.CreateDirectory(library.DirectoryPath);
            library.ExistsOnDisk = true;
            return _imageLibraryRepository.AddLibrary(library);
        }

        public Image DownloadImageToLibrary(string imageUrl, string imageFileName, Library library)
        {
            var imagePath = Path.Combine(library.DirectoryPath, imageFileName);
            _webClient.DownloadFile(imageUrl, imagePath);

            var imageToAdd = new Image
            {
                FilePath = imagePath,
                Name = Path.GetFileNameWithoutExtension(imageFileName),
                ExistsOnDisk = true,
                Library = library
            };

            return _imageLibraryRepository.AddImageToLibrary(imageToAdd);
        }

        public List<Library> GetLibraries()
        {
            var libraries = _imageLibraryRepository.GetLibrariesWithoutImages();
            return libraries.Select(lib =>
            {
                lib.ExistsOnDisk = _fileSystem.IsDirectoryExists(lib.DirectoryPath);
                if (lib.ExistsOnDisk)
                {
                    lib.Images = _imageLibraryRepository.GetImagesOfLibrary(lib.Id)?.Select(img =>
                    {
                        img.ExistsOnDisk = _fileSystem.IsFileExists(img.FilePath);
                        return img;
                    }).ToList();
                }
                return lib;
            }).ToList();
        }

        public Library RemoveImageFromLibrary(Image image)
        {
            _fileSystem.RemoveFile(image.FilePath);
            return _imageLibraryRepository.RemoveImageFromLibrary(image.Library.Id, image.Id);
        }

        public void RemoveLibrary(Library library)
        {
            _fileSystem.RemoveDirectoryWithContent(library.DirectoryPath);

            library.Images?.ForEach(img => _imageLibraryRepository.RemoveImageFromLibrary(library.Id, img.Id));

            _imageLibraryRepository.RemoveLibrary(library.Id);
        }
    }
}
