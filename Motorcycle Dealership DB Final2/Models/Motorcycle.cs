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
        [Range(1900, 2024, ErrorMessage = "Please enter a valid Model year (1900 - 2024")]
        public int Year { get; set; }
        [Required]
        [Range(0, 2000, ErrorMessage = "Please enter a valid weight from 0 - 2000")]
        public string Weight { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(25)]
        public string Colour { get; set; }


        public ICollection<Inventory> Inventory { get; set; }
    }
}
