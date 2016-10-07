using FlickrNet;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotosSearchWPF.Model
{
    public class InMemoryPhotoLibraryRepository : IPhotoLibraryRepository
    {
        private List<string> _libraries;
        private List<string> _lib1Photos;
        private List<string> _lib2Photos;
        private List<string> _lib3Photos;

        public InMemoryPhotoLibraryRepository()
        {
            _libraries = new List<string> { "Lib1", "Lib2", "Lib3" };
            _lib1Photos = new List<string> { "Photo_1/1", "Photo_1/2", "Photo_1/3" };
            _lib2Photos = new List<string> { "Photo_2/1", "Photo_2/2" };
            _lib3Photos = new List<string> { "Photo_3/1", "Photo_3/2", "Photo_3/3", "Photo_3/4", "Photo_3/5", "Photo_3/6" };
        }

        public async Task<List<string>> GetLibraryNames()
        {
            return await Task.Run(() =>
            {
                return _libraries;
            });
        }

        public async Task AddLibrary(string newLibraryName)
        {
            await Task.Run(() => _libraries.Add(newLibraryName));
        }

        public async Task<List<string>> GetPhotosOfLibrary(string libraryName)
        {
            return await Task.Run(() =>
            {
                switch (libraryName)
                {
                    case "Lib1": return _lib1Photos;
                    case "Lib2": return _lib2Photos;
                    case "Lib3": return _lib3Photos;
                }

                return new List<string>();
            });
        }

        public async Task DownloadPhotoFromUrlToLibrary(Photo photo, string libraryName)
        {
            await Task.Run(() =>
            {
                switch (libraryName)
                {
                    case "Lib1": _lib1Photos.Add(photo.PhotoId);
                        break;
                    case "Lib2": _lib2Photos.Add(photo.PhotoId);
                        break;
                    case "Lib3": _lib3Photos.Add(photo.PhotoId);
                        break;
                    default: throw new ArgumentException($"Library name not recognized: {libraryName}");
                }
            });
        }
    }
}
