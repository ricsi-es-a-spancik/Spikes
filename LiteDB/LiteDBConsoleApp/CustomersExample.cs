using LiteDB;
using LiteDBConsoleApp.Model;
using System;
using System.Linq;

namespace LiteDBConsoleApp
{
    public static class CustomersExample
    {
        public static void Run()
        {
            // open db
            var dbName = $"customers-{Guid.NewGuid().ToString()}.db";
            using (var db = new LiteDatabase($@"Data/{dbName}"))
            {
                Console.WriteLine($"Database created: {dbName}");

                // create customers collection
                var customers = db.GetCollection<Customer>("customers");

                Console.WriteLine("\nInserting customers to collection...");
                customers.Insert(Repository.CustomerJohnDoe);
                customers.Insert(Repository.CustomerJaneDoe);

                // read customers
                Utilities.PrintCollection(customers);

                // find John
                customers.EnsureIndex(cust => cust.Name);

                Console.WriteLine("\nFinding John...");
                var documentForJohn = customers.Find(cust => cust.Name.StartsWith("John")).FirstOrDefault();
                Console.WriteLine(documentForJohn);

                Console.WriteLine("\nClosing database...");
            }

            // reopen database
            using (var db = new LiteDatabase($@"Data/{dbName}"))
            {
                Console.WriteLine("\nDatabase reopened.");
                var customers = db.GetCollection<Customer>("customers");

                // update a customer
                Console.WriteLine("\nUpdating Janes record...");

                var documentForJane = customers.Find(cust => cust.Name == "Jane Doe").FirstOrDefault();
                documentForJane.Phones.Add(new Phone { Code = 2, Number = "069-295-6558", Type = PhoneType.Mobile });
                customers.Update(documentForJane);

                // read customers
                Utilities.PrintCollection(customers);

                // delete a customer
                Console.WriteLine("\nDeleting Jane...");
                customers.Delete(documentForJane.Id);

                // read customers
                Utilities.PrintCollection(customers);
            }
        }
    }
}
