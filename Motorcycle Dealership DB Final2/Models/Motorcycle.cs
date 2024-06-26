using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Motorcycle
    {
        //primary key//
        public int MotorcycleID { get; set; }

        //model of the motorcycle and is limited to 25 characters//
        [Required]
        [StringLength(25)]
        public string Model { get; set; }

        //the year of the model has to be between 1900 and 2024//
        [Required]
        [Range(1900, 2024, ErrorMessage = "Please enter a vaild year (1900 - 2024)")]
        public int Year { get; set; }

        //the weight of the model is a string to write "KG" and is limited to 10 characters//
        [Required]
        [StringLength(10)]
        public string Weight { get; set; }

        //colour of the model, and is limited to 10 characters//
        [Required]
        [StringLength(10)]
        public string Colour { get; set; }


        public ICollection<Inventory> Inventory { get; set; }
    }
}
