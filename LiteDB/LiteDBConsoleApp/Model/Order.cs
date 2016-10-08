using System;
using System.Collections.Generic;

namespace LiteDBConsoleApp.Model
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public Address ShippingAddress { get; set; }

        public Customer Customer { get; set; }

        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return $"Order #{Id}\n  at {OrderDate}\n  shipping to {ShippingAddress}\n  for customer {Customer}\n  with products:\n     {string.Join("\n     ", Products)}";
        }
    }
}
