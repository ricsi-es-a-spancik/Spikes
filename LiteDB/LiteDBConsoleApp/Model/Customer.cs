using System;
using System.Collections.Generic;
using LiteDB;

namespace LiteDBConsoleApp.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Phone> Phones { get; set; }

        public override string ToString()
        {
            return $"Customer #{Id} {Name}, phones: {string.Join(", ", Phones)}";
        }
    }
}
