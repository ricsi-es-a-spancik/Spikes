using LiteDB;
using System.Configuration;
using System.IO;

namespace PhotosSearchWPF.Data
{
    public class ImageLibraryContext : LiteDatabase
    {
        private static string ReadConnectionString(string connectionStringName)
        {
            var dbFilePath = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            if (!File.Exists(dbFilePath))
                Directory.CreateDirectory(Path.GetDirectoryName(dbFilePath));
            return dbFilePath;
        }

        public ImageLibraryContext(string connectionString = "ImageLibraryContext")
            : base(ReadConnectionString(connectionString))
        {
        }
    }
}