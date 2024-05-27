using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Motorcycle
    {
        public int MotorcycleID { get; set; }

        [Required]
        [StringLength(25)]
        public string Model { get; set; }

        [Required]
        [Range(1900, 2024, ErrorMessage = "Please enter a vaild year (1900 - 2024)")]
        public int Year { get; set; }

        [Required]
        [StringLength(10)]
        public string Weight { get; set; }

        [Required]
        [StringLength(10)]
        public string Colour { get; set; }


        public ICollection<Inventory> Inventory { get; set; }
    }
}
