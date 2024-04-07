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
        }
    }
}
