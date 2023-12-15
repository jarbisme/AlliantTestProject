using AlliantTestProject.Data.Models;

namespace AlliantTestProject.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            // Insert Customers
            var customers = new Customer[]
            {
                new Customer()
                {
                    CustomerNumber = 1020,
                    CustomerName = "Mario Bros",
                    Email = "mario@email.com",
                    Phone = "8290832135",
                },
                new Customer()
                {
                    CustomerNumber = 1022,
                    CustomerName = "King Koopa Bowser",
                    Email = "kingkb@email.com",
                    Phone = "18889382334",
                },
                new Customer()
                {
                    CustomerNumber = 2020,
                    CustomerName = "Eren Yaager",
                    Email = "attacktitan@email.com",
                    Phone = "8290818435",
                },
                new Customer()
                {
                    CustomerNumber = 2025,
                    CustomerName = "Julia Juliana",
                    Email = "jjuliana@email.com",
                    Phone = "6450832135",
                },
            };

            db.Customers.AddRange(customers);
            db.SaveChanges();

            // Insert Items
            var items = new Item[]
            {
                new Item()
                {
                    ItemNumber = 10,
                    Description = "Water Bottle",
                    DefaultPrice = 29.99,
                    ItemCategory = "C",
                },
                new Item()
                {
                    ItemNumber = 15,
                    Description = "Backpack",
                    DefaultPrice = 144.99,
                    ItemCategory = "C",
                },
                new Item()
                {
                    ItemNumber = 220,
                    Description = "Giant Sword",
                    DefaultPrice = 1100,
                    ItemCategory = "A",
                },
                new Item()
                {
                    ItemNumber = 305,
                    Description = "Phone",
                    DefaultPrice = 999.99,
                    ItemCategory = "B",
                },
                new Item()
                {
                    ItemNumber = 310,
                    Description = "Mechanical Keyboard C23",
                    DefaultPrice = 137.50,
                    ItemCategory = "B",
                },
                new Item()
                {
                    ItemNumber = 1010,
                    Description = "BLack Matter Lb",
                    DefaultPrice = 370.50,
                    ItemCategory = "X",
                },
            };

            db.Items.AddRange(items);
            db.SaveChanges();

            // Insert Customer Items
            var customerItems = new CustomerItem[]
            {
                new CustomerItem()
                {
                    CustomerId = customers[0].CustomerId,
                    ItemId = items[2].ItemId,
                    Quantity = 4,
                    Price = 1948,
                },
                new CustomerItem()
                {
                    CustomerId = customers[0].CustomerId,
                    ItemId = items[5].ItemId,
                    Quantity = 34.2,
                    Price = 19348,
                },
                new CustomerItem()
                {
                    CustomerId = customers[2].CustomerId,
                    ItemId = items[1].ItemId,
                    Quantity = 40,
                    Price = 23800,
                },
                new CustomerItem()
                {
                    CustomerId = customers[1].CustomerId,
                    ItemId = items[2].ItemId,
                    Quantity = 12.4,
                    Price = 489,
                },
                new CustomerItem()
                {
                    CustomerId = customers[2].CustomerId,
                    ItemId = items[04].ItemId,
                    Quantity = 1,
                    Price = 380,
                },
                new CustomerItem()
                {
                    CustomerId = customers[2].CustomerId,
                    ItemId = items[4].ItemId,
                    Quantity = 3,
                    Price = 142.78,
                },
                new CustomerItem()
                {
                    CustomerId = customers[0].CustomerId,
                    ItemId = items[1].ItemId,
                    Quantity = 3,
                    Price = 988,
                },
                new CustomerItem()
                {
                    CustomerId = customers[1].CustomerId,
                    ItemId = items[2].ItemId,
                    Quantity = 4.4,
                    Price = 13422.78,
                },
                new CustomerItem()
                {
                    CustomerId = customers[0].CustomerId,
                    ItemId = items[4].ItemId,
                    Quantity = 32,
                    Price = 59828,
                },
            };

            db.CustomerItems.AddRange(customerItems);
            db.SaveChanges();
        }
    }
}
