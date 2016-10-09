using LiteDB;
using System;
using System.Linq;

namespace LiteDBConsoleApp
{
    public static class Utilities
    {
        public static void PrintCollection<T>(LiteCollection<T> collection) where T : new()
        {
            Console.WriteLine($"\nReading documents from collection '{collection.Name}'...");
            var documentsFromDb = collection.FindAll().ToList();

            foreach (var doc in documentsFromDb)
                if (doc != null)
                    Console.WriteLine(doc);
        }
    }
}
