using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosSearchWPF.Model
{
    public class InMemoryPhotoLibraryRepository : IPhotoLibraryRepository
    {
        private Dictionary<string, List<string>> _libraries;
        private List<string> _lib1Photos;
        private List<string> _lib2Photos;
        private List<string> _lib3Photos;

        public InMemoryPhotoLibraryRepository()
        {
            _libraries = new Dictionary<string, List<string>>
            {
                { "Lib1", new List<string> { "Photo_1/1", "Photo_1/2", "Photo_1/3" } },
                { "Lib2", new List<string> { "Photo_2/1", "Photo_2/2" } },
                { "Lib3", new List<string> { "Photo_3/1", "Photo_3/2", "Photo_3/3", "Photo_3/4", "Photo_3/5", "Photo_3/6" } }
            };
        }

        public Task<List<string>> GetLibraryNames()
        {
            return Task.Run(() => _libraries.Keys.ToList());
        }

        public Task AddLibrary(string newLibraryName)
        {
            return Task.Run(() => _libraries.Add(newLibraryName, new List<string>()));
        }

        public Task<List<string>> GetPhotosOfLibrary(string libraryName)
        {
            return Task.Run(() =>
            {
                if (_libraries.ContainsKey(libraryName))
                    return _libraries[libraryName];

                throw new ArgumentException($"Couldn't find library in repository: {libraryName}");
            });
        }

        public Task DownloadPhotoFromUrlToLibrary(Photo photo, string libraryName)
        {
            return Task.Run(() =>
            {
                if (_libraries.ContainsKey(libraryName))
                {
                    _libraries[libraryName].Add(photo.PhotoId);
                    return;
                }

                throw new ArgumentException($"Library name not recognized: {libraryName}");
            });
        }

        public Task DeleteLibrary(string libraryName)
        {
            return Task.Run(() => _libraries.Remove(libraryName));
        }
    }
}
