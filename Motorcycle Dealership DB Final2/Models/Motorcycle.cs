namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Motorcycle
    {
        public int MotorcycleID { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Weight { get; set; }
        public string Colour { get; set; }


        public ICollection<Inventory> Inventory { get; set; }
    }
}
