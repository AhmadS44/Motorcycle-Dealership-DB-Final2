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
           new Customer {FirstName= "Daniel", LastName="Patel", PhoneNumber=021728281, Address= "25 Main Street, Auckland Central", Email="Danielpatel@gmail.com"},
           new Customer {FirstName= "Emily", LastName="Johnson", PhoneNumber=028228531, Address= "10 Park Avenue, Remuera", Email="emilyj@gmail.com"},
           new Customer {FirstName= "Sophia", LastName="Williams", PhoneNumber=021922581, Address= "7 Elm Road, Mount Eden", Email="Swilliams22@gmail.com"},
           new Customer {FirstName= "Ethan", LastName="Browns", PhoneNumber=021758299, Address= "36 Beach Road, Takapuna", Email="ethanB@gmail.com"},
           new Customer {FirstName= "Olivia", LastName="Davis", PhoneNumber=021724291, Address= "14 Oak Street, Ponsonby", Email="oliviaDa88@gmail.com"},
           new Customer {FirstName= "Jacob", LastName="Martinez", PhoneNumber=021128741, Address= "3 Maple Crescent, Albany", Email="jacobMartinez22@gmail.com"},
           new Customer {FirstName= "Ava", LastName="Garcia", PhoneNumber=021918281, Address= "45 Pine Avenue, Epsom", Email="avag9@gmail.com"},
           new Customer {FirstName= "William", LastName="Jones", PhoneNumber=021723821, Address= "22 Willow Lane, Newmarket", Email="williamj21@gmail.com"},
           new Customer {FirstName= "Isabella", LastName="Rodriguez", PhoneNumber=021298771, Address= "18 Cedar Grove, Henderson", Email="irodriguez2@gmail.com"},
            new Customer { FirstName = "Liam", LastName = "Anderson", PhoneNumber = 0217912381, Address = "29 Birch Street, Howick", Email = "liamanderson0@gmail.com" },
            };
            foreach (Customer c in customers)
            {
                context.Customer.Add(c);
            }
            context.SaveChanges();
            ;

            var motorcycles = new Motorcycle[]
             {
           new Motorcycle {Model= "Honda CB750", Year=1979, Weight= "230Kg", Colour="Black"},
           new Motorcycle {Model= "Yamaha MT-09", Year=2023, Weight= "188Kg", Colour="Blue"},
           new Motorcycle {Model= "Harley-Davidson Fat Boy", Year=2018, Weight= "330Kg", Colour="Silver"},
           new Motorcycle {Model= "Kawasaki Z900", Year=2022, Weight= "210Kg", Colour="Green"},
           new Motorcycle {Model= "Suzuki Hayabusa", Year=2021, Weight= "264Kg", Colour="Red"},
           new Motorcycle {Model= "Ducati Monster", Year=2019, Weight= "185Kg", Colour="Yellow"},
           new Motorcycle {Model= "BMW R1250GS", Year=2020, Weight= "249Kg", Colour="White"},
           new Motorcycle {Model= "Triumph Bonneville T120", Year=2017, Weight= "224Kg", Colour="Black"},
           new Motorcycle {Model= "KTM 390 Duke", Year=2024, Weight= "224Kg", Colour="Orange"},
           new Motorcycle {Model= "Aprilia Tuono V4", Year=2016, Weight= "184Kg", Colour="Gray"},
              };
            foreach (Motorcycle m in motorcycles)
            {
                context.Motorcycle.Add(m);
            }
            context.SaveChanges();


            var inventorys = new Inventory[]
            {
           new Inventory {MotorcycleID= 1, Model= "Honda CB750", PhoneNumber= 0216421822, Email= "inventory1@gmail.com", Function="Selling"},
           new Inventory {MotorcycleID= 2, Model= "Yamaha MT-09", PhoneNumber= 0212819272, Email= "inventorystorage2@gmail.com", Function="Selling"},
           new Inventory {MotorcycleID= 3, Model= "Harley-Davidson Fat Boy", PhoneNumber= 0217281002, Email= "inventorystorage3@gmail.com", Function="Display"},
           new Inventory {MotorcycleID= 4, Model= "Kawasaki Z900", PhoneNumber= 0219927372, Email= "inventorystorage4@gmail.com", Function="Out of Stock"},
           new Inventory {MotorcycleID= 5, Model= "Suzuki Hayabusa", PhoneNumber= 0218192187, Email= "inventorystorage5@gmail.com", Function="Out of Stock"},
           new Inventory {MotorcycleID= 6, Model= "Ducati Monster", PhoneNumber= 0212882682, Email= "inventorystorage6@gmail.com", Function="Selling"},
           new Inventory {MotorcycleID= 7, Model= "BMW R1250GS", PhoneNumber= 0211826182, Email= "inventorystorage7@gmail.com", Function="Selling"},
           new Inventory {MotorcycleID= 8, Model= "Triumph Bonneville T120", PhoneNumber= 0212777102, Email= "inventorystorage8@gmail.com", Function="Display"},
           new Inventory {MotorcycleID= 9, Model= "KTM 390 Duke", PhoneNumber= 0212528271, Email= "inventorystorage9@gmail.com", Function="Selling"},
           new Inventory {MotorcycleID= 10, Model= "Aprilia Tuono V4", PhoneNumber= 0212826062, Email= "inventorystorage10@gmail.com", Function="Selling"},
            };
            foreach (Inventory i in inventorys)
            {
                context.Inventory.Add(i);
            }
            context.SaveChanges();


            var locations = new Location[]
            {
           new Location {Country="New Zealand", City="Auckland", Address= "42 Pine Street, Grey Lynn", Zip=1021, PhoneNumber=0211861736},
           new Location {Country="New Zealand", City="Auckland", Address= "15 Ocean Avenue, Devonport", Zip=0624, PhoneNumber=0218273617},
           new Location {Country="New Zealand", City="Christchurch", Address= "25 Cathedral Square, Christchurch Central", Zip=8011, PhoneNumber=0219273716},
           new Location {Country="New Zealand", City="Auckland", Address= "28 Elm Road, Mount Eden", Zip=1024, PhoneNumber=0218846673},
           new Location {Country="New Zealand", City="Auckland", Address= "9 Harbour View Terrace, Herne Bay", Zip=1011, PhoneNumber=0218292837},
           new Location {Country="New Zealand", City="Auckland", Address= "56 Beach Road, Takapuna", Zip=0622, PhoneNumber=0218268274},
           new Location {Country="New Zealand", City="Wellington", Address= "7 Kelburn Parade, Kelburn", Zip=6012, PhoneNumber=0218261721},
           new Location {Country="New Zealand", City="Wellington", Address= "18 Lamton Quay, Wellington Central", Zip=6011, PhoneNumber=0218261928},
           new Location {Country="New Zealand", City="Auckland", Address= "37 Queen Street, Auckland Central", Zip=1010, PhoneNumber=0218734824},
           new Location {Country="New Zealand", City="Auckland", Address= "63 Hillside Road, Parnell", Zip=1052, PhoneNumber=0218831124},
            };
            foreach (Location l in locations)
            {
                context.Location.Add(l);
            }
            context.SaveChanges();

            var suppliers = new Supplier[]
          {
           new Supplier {LocationID= 1, InventoryID=1, FirstName="Natalie", LastName= "Reynolds", PhoneNumber=02127726123, Email="nataliereynolds@gmail.com", City="Auckland", Address="42 Pine Street, Grey Lynn", Zip=1021},
           new Supplier {LocationID= 2, InventoryID=2, FirstName="Connor", LastName= "Mitchell", PhoneNumber=0218273672, Email="connorm1@gmail.com", City="Auckland", Address="15 Ocean Avenue, Devonport", Zip=0624},
           new Supplier {LocationID= 3, InventoryID=3, FirstName="Harper", LastName= "Evans", PhoneNumber=0219283714, Email="harperevan22@gmail.com", City="Christchurch", Address="25 Cathedral Square, Christchurch Central", Zip=8011},
           new Supplier {LocationID= 4, InventoryID=4, FirstName="Sebastian", LastName= "Hayes", PhoneNumber=0212928371, Email="sebastianH2@gmail.com", City="Auckland", Address="28 Elm Road, Mount Eden", Zip=1024},
           new Supplier {LocationID= 5, InventoryID=5, FirstName="Madison", LastName= "Clarke", PhoneNumber=0219817378, Email="MadisonCl@gmail.com", City="Auckland", Address="9 Harbour View Terrace, Herne Bay", Zip=1011},
           new Supplier {LocationID= 6, InventoryID=6, FirstName="Logan", LastName= "Ramirez", PhoneNumber=0219823598, Email="loganramirez222@gmail.com", City="Auckland", Address="56 Beach Road, Takapuna", Zip=0622},
           new Supplier {LocationID= 7, InventoryID=7, FirstName="Harper", LastName= "Nguyen", PhoneNumber=0219238533, Email="harperisme21@gmail.com", City="Wellington", Address="7 Kelburn Parade, Kelburn", Zip=6012},
           new Supplier {LocationID= 8, InventoryID=8, FirstName="Benjamin", LastName= "Campbell", PhoneNumber=0212718372, Email="benny281@gmail.com", City="Wellington", Address="18 Lamton Quay, Wellington Central", Zip=6011},
           new Supplier {LocationID= 9, InventoryID=9, FirstName="Stella", LastName= "Thompson", PhoneNumber=0204329023, Email="stellaswork22@gmail.com", City="Auckland", Address="37 Queen Street, Auckland Central", Zip=1010},
           new Supplier {LocationID= 10, InventoryID=10, FirstName="Carter", LastName= "Morgan", PhoneNumber=0213570928, Email="morgansur22@gmail.com", City="Auckland", Address="63 Hillside Road, Parnell", Zip=1052},
          };
            foreach (Supplier s in suppliers)
            {
                context.Supplier.Add(s);
            }
            context.SaveChanges();



            var purchaseorders = new PurchaseOrder[]
            {
           new PurchaseOrder {CustomerID= 1, PurchaseDate=DateTime.Parse("2002-06-11"), Model="Yamaha MT-07", Zip=1021, PhoneNumber=0217817819},
           new PurchaseOrder {CustomerID= 2, PurchaseDate=DateTime.Parse("2004-01-12"), Model="Honda Africa Twin", Zip=0624, PhoneNumber=0282185312},
           new PurchaseOrder {CustomerID= 3, PurchaseDate=DateTime.Parse("2001-09-08"), Model="Suzuki V-Strom", Zip=8011, PhoneNumber=0219218815},
           new PurchaseOrder {CustomerID= 4, PurchaseDate=DateTime.Parse("2010-12-06"), Model="Kawasaki Versys", Zip=1024, PhoneNumber=0217927992},
           new PurchaseOrder {CustomerID= 5, PurchaseDate=DateTime.Parse("2007-07-02"), Model="Harley-Davidson", Zip=1011, PhoneNumber=0217242918},
           new PurchaseOrder {CustomerID= 6, PurchaseDate=DateTime.Parse("2006-02-08"), Model="BMW R nineT", Zip=1021, PhoneNumber=0211292413},
           new PurchaseOrder {CustomerID= 7, PurchaseDate=DateTime.Parse("2014-04-07"), Model="Triumph Tiger", Zip=6012, PhoneNumber=0212972816},
           new PurchaseOrder {CustomerID= 8, PurchaseDate=DateTime.Parse("2011-11-07"), Model="Ducati Multistrada", Zip=6011, PhoneNumber=0217238215},
           new PurchaseOrder {CustomerID= 9, PurchaseDate=DateTime.Parse("2009-04-01"), Model="KTM 690 Enduro R", Zip=8011, PhoneNumber=0212292718},
           new PurchaseOrder {CustomerID= 10, PurchaseDate=DateTime.Parse("2012-06-05"), Model="Aprilia Caponord 1200", Zip=6011, PhoneNumber=0212923819},
            };
            foreach (PurchaseOrder p in purchaseorders)
            {
                context.PurchaseOrder.Add(p);
            }
            context.SaveChanges();

        }
    }
}
