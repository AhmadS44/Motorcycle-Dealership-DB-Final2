using Motorcycle_Dealership_DB_Final2.Models;

namespace Motorcycle_Dealership_DB_Final2.Areas.Identity.Data
{
    public class DBInitializer
    {
        internal static void Initialize(Motorcycle_Dealership_DB_Final2Context context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customer.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
           new Customer {FirstName= "Daniel", LastName="Patel", PhoneNumber=021728281, Address= "122 Mount Street, Auckland", Email="Danielpatel@gmail.com"}
            };
            foreach (Customer c in customers)
            {
                context.Customer.Add(c);
            }
            context.SaveChanges();
            ;

            var motorcycles = new Motorcycle[]
             {
           new Motorcycle {Model= "Toyota", Year=1999, Weight= "160kg", Colour="Silver"}
              };
            foreach (Motorcycle m in motorcycles)
            {
                context.Motorcycle.Add(m);
            }
            context.SaveChanges();


            var inventorys = new Inventory[]
            {
           new Inventory {MotorcycleID= 1, Model= "Toyota", PhoneNumber= 0212826182, Email= "inventorystorage1@gmail.com", Function="Storage"}
            };
            foreach (Inventory i in inventorys)
            {
                context.Inventory.Add(i);
            }
            context.SaveChanges();


            var locations = new Location[]
            {
           new Location {Country="New Zealand", City="Auckland", Address= "92 Woolworth Street", Zip=2821, PhoneNumber=0218261824}
            };
            foreach (Location l in locations)
            {
                context.Location.Add(l);
            }
            context.SaveChanges();

            var suppliers = new Supplier[]
          {
           new Supplier {LocationID= 1, InventoryID=1, FirstName="Carl", LastName= "Joseph", PhoneNumber=0212718272, Email="carlj@gmail.com", City="Auckland", Address="172 Blockhousebay Rd", Zip=1029}
          };
            foreach (Supplier s in suppliers)
            {
                context.Supplier.Add(s);
            }
            context.SaveChanges();



            var purchaseorders = new PurchaseOrder[]
            {
           new PurchaseOrder {CustomerID= 1, PurchaseDate=DateTime.Parse("2002-07-02"), Model="Toyota", Zip=9281, PhoneNumber=0212727122}
            };
            foreach (PurchaseOrder p in purchaseorders)
            {
                context.PurchaseOrder.Add(p);
            }
            context.SaveChanges();

        }
    }
}
