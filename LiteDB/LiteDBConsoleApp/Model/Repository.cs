using System.Collections.Generic;

namespace LiteDBConsoleApp.Model
{
    public static class Repository
    {
        // Addresses
        public static Address AddressBudapest = new Address
        {
            PostalCode = 1114,
            Residence = "OneStreet 4."
        };

        public static Address AddressLondon = new Address
        {
            PostalCode = 15493,
            Residence = "Other Street 23."
        };

        public static Address AddressSanFrancisco = new Address
        {
            PostalCode = 11223,
            Residence = "Third Street 33."
        };

        // Customers
        public static Customer CustomerJohnDoe = new Customer
        {
            Name = "John Doe",
            Phones = new List<Phone>
                    {
                        new Phone { Code = 1, Number = "001-234-567", Type = PhoneType.Landline },
                        new Phone { Code = 2, Number = "069-112-1234", Type = PhoneType.Mobile }
                    }
        };

        public static Customer CustomerJaneDoe = new Customer
        {
            Name = "Jane Doe",
            Phones = new List<Phone>
                    {
                        new Phone { Code = 1, Number = "002-235-645", Type = PhoneType.Landline }
                    }
        };

        // Products
        public static Product ProductMilk = new Product
        {
            Name = "Milk"
        };

        public static Product ProductEgg = new Product
        {
            Name = "Egg"
        };

        public static Product ProductBread = new Product
        {
            Name = "Bread"
        };

        public static Product ProductBeer = new Product
        {
            Name = "Beer"
        };

        public static Product ProductCheese = new Product
        {
            Name = "Cheese"
        };
    }
}
