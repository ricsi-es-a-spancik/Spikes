using LiteDB;
using LiteDBConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiteDBConsoleApp
{
    public static class OrdersExample
    {
        public static void Run()
        {
            // Re-use mapper from global instance
            var mapper = BsonMapper.Global;

            // "Produts" and "Customer" are from other collections (not embedded document)
            mapper.Entity<Order>()
                  .DbRef(x => x.Customer, "customers")   // 1 to 1/0 reference
                  .DbRef(x => x.Products, "products")    // 1 to Many reference
                  .Field(x => x.ShippingAddress, "addr") // Embedded sub document
                  .Index(x => x.OrderDate);              // Index this field

            // open db
            //var dbName = $"orders-{Guid.NewGuid().ToString()}.db";
            //using (var db = new LiteDatabase($@"Data/{dbName}"))
            using (var db = new OrdersContext())
            {
                Console.WriteLine("Adding document to database...");

                // create collection
                var orders = db.GetCollection<Order>("orders");

                // add documents
                var customers = db.GetCollection<Customer>("customers");
                var documentJohnDoe = customers.Insert(Repository.CustomerJohnDoe);
                var documentJaneDoe = customers.Insert(Repository.CustomerJaneDoe);

                var products = db.GetCollection<Product>("products");
                var documentMilk = products.Insert(Repository.ProductMilk);
                var documentEgg = products.Insert(Repository.ProductEgg);
                var documentBread = products.Insert(Repository.ProductBread);
                var documentBeer = products.Insert(Repository.ProductBeer);
                var documentCheese = products.Insert(Repository.ProductCheese);

                var order1 = new Order
                {
                    OrderDate = DateTime.UtcNow,
                    ShippingAddress = Repository.AddressBudapest,
                    Customer = new Customer { Id = documentJaneDoe },
                    Products = new List<Product>
                    {
                        new Product { Id = documentMilk },
                        new Product { Id = documentBread },
                        new Product { Id = documentEgg }
                    }
                };

                var order2 = new Order
                {
                    OrderDate = DateTime.UtcNow,
                    ShippingAddress = Repository.AddressLondon,
                    Customer = new Customer { Id = documentJohnDoe },
                    Products = new List<Product>
                    {
                        new Product { Id = documentMilk },
                        new Product { Id = documentBeer },
                        new Product { Id = documentEgg },
                        new Product { Id = documentCheese },
                        new Product { Id = documentBread },
                    }
                };

                var documentOrder1 = orders.Insert(order1);
                var documentOrder2 = orders.Insert(order2);

                // read collections
                var collections = db.GetCollectionNames();

                Console.WriteLine("\nCollections in database:");
                foreach (var collectionName in collections)
                    Console.WriteLine($"\t{collectionName}");

                var ordersFromDb = orders.Include(o => o.Customer)
                                         .Include(o => o.Products)
                                         .FindAll();

                Console.WriteLine("\nOrders from database:");
                foreach (var order in ordersFromDb)
                    Console.WriteLine($"\n{order}");

                // Adding new product to order
                order1.Products.Add(new Product { Id = documentBeer });
                orders.Update(order1);
                var newOrder1 = orders.Include(o => o.Customer)
                                         .Include(o => o.Products)
                                         .Find(o => o.Id == order1.Id)
                                         .FirstOrDefault();

                Console.WriteLine("\norder1 after update:");
                Console.WriteLine(newOrder1);
            }
        }
    }
}
