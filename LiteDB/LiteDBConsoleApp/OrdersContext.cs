using LiteDB;
using System.Configuration;
using System.IO;

namespace LiteDBConsoleApp
{
    public class OrdersContext : LiteDatabase
    {
        private static string ReadConnectionString(string connectionStringName)
        {
            var dbFilePath = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            Directory.CreateDirectory(Path.GetDirectoryName(dbFilePath));
            return dbFilePath;
        }

        public OrdersContext(string connectionString = "OrdersDbContext")
            : base(ReadConnectionString(connectionString))
        {
        }
    }
}
