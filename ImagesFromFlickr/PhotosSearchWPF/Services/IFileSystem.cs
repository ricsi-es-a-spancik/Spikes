namespace PhotosSearchWPF.Services
{
    public interface IFileSystem
    {
        bool IsFileExists(string path);

        bool IsDirectoryExists(string path);

        void CreateDirectory(string path);

        void RemoveFile(string path);

        void RemoveDirectoryWithContent(string path);
    }
}
