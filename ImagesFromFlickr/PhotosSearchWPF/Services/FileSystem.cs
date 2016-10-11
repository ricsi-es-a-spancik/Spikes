using System.IO;

namespace PhotosSearchWPF.Services
{
    public class FileSystem : IFileSystem
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public bool IsDirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool IsFileExists(string path)
        {
            return File.Exists(path);
        }

        public void RemoveDirectoryWithContent(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }

        public void RemoveFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
