namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public int PhoneNumber { get; set; }


        public ICollection<Supplier> Supplier { get; set; }
    }
}
