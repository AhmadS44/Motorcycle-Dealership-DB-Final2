namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Model { get; set; }
        public int Zip { get; set; }
        public int PhoneNumber {  get; set; }  


        public Customer customer { get; set; }
    }
}
