using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public int LocationID { get; set; }
        public int InventoryID {  get; set; }
       
        public string FirstName {get; set; }
        
        public string LastName { get; set; }
       
        public int PhoneNumber { get; set; }
        
        public string Email { get; set; }
        
        public string City { get; set; }
        
        public string Address { get; set; }
        
        public int Zip {  get; set; }


        public Location Location { get; set; }
        public Inventory Inventory { get; set; }
    }
}
