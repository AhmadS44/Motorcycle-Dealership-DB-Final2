using Motorcycle_Dealership_DB_Final2.Models;

namespace Motorcycle_Dealership_DB_Final2.Areas.Identity.Data
{
    public class DBInitializer
    {
        internal static void Initializer(Motorcycle_Dealership_DB_Final2Context context)
        {
            if (context.Customer.Any());
            {
                return;
            }

            var customer = new Customer[]
            {
                new Customer {FirstName= "Daniel", LastName="Patel", PhoneNumber=021728281, Address= "122 Mount Street, Auckland", Email="Danielpatel@gmail.com"}
            };
            foreach (Customer c in customer)
            {
                context.Customer.Add(c);
            }

            if (context.Customer.Any()) ;
            {
                return;
            }


            var supplier = new Supplier[]
            {
                new Supplier {LocationID= 1, InventoryID=1, FirstName="Carl", LastName= "Joseph", PhoneNumber=0212718272, Email="carlj@gmail.com", City="Auckland", Address="172 Blockhousebay Rd", Zip=1029}
            };
            foreach (Supplier s in supplier)
            {
                context.Supplier.Add(s);
            }

            if (context.Supplier.Any()) ;
            {
                return;
            }


            var inventory = new Inventory[]
            {
                new Inventory {MotorcycleID= 1, Model= "Toyota", PhoneNumber= 0212826182, Email= "inventorystorage1@gmail.com", Function="Storage"}
            };
            foreach (Inventory i in inventory)
            {
                context.Inventory.Add(i);
            }

            if (context.Inventory.Any()) ;
            {
                return;
            }


            var location = new Location[]
            {
                new Location {Country="New Zealand", City="Auckland", Address= "92 Woolworth Street", Zip=2821, PhoneNumber=0218261824}
            };
            foreach (Location l in location)
            {
                context.Location.Add(l);
            }

            if (context.Location.Any()) ;
            {
                return;
            }


            var motorcycle = new Motorcycle[]
            {
                new Motorcycle {Model= "Toyota", Year=1999, Weight= "160kg", Colour="Silver"}
            };
            foreach (Motorcycle m in motorcycle)
            {
                context.Motorcycle.Add(m);
            }

            if (context.Motorcycle.Any()) ;
            {
                return;
            }


            var PurchaseOrder = new PurchaseOrder[]
            {
                new PurchaseOrder {CustomerID= 1, PurchaseDate=DateTime.Parse("2002-07-02"), Model="Toyota", Zip=9281, PhoneNumber=0212727122}
            };
            foreach (PurchaseOrder p in PurchaseOrder)
            {
                context.PurchaseOrder.Add(p);
            }

            if (context.PurchaseOrder.Any()) ;
            {
                return;
            }
        }
    }
}
