using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int MotorcycleID { get; set; }
        
        public string Model { get; set; }
      
        public int PhoneNumber { get; set; }
       
        public string Email { get; set;}
       
        public string Function { get; set; }   


        public Motorcycle motorcycle { get; set; }
        public ICollection<Supplier> Supplier { get; set; }
    }
}
