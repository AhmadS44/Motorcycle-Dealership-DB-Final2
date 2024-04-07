namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }


        public ICollection<PurchaseOrder> PurchaseOrder { get; set; } 
    }
}
