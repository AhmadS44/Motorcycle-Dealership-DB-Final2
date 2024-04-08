using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int MotorcycleID { get; set; }
        [Required]
        [StringLength(25)]
        public string Model { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "The phone number field should have a maximum of 10 characters. ")]
        [Range(0100000000, 9999999999, ErrorMessage = "Please enter a valid phone number (021-0000000)")]
        [Display(Name = "PhoneNumber")]
        public int PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set;}
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(25)]
        public string Function { get; set; }   


        public Motorcycle motorcycle { get; set; }
        public ICollection<Supplier> Supplier { get; set; }
    }
}
