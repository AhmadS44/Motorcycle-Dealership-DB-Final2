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
        [Range(0210000000, 0219999999, ErrorMessage = "Please enter a vaild phone number (021-0000000)")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set;}

        [Required]
        [StringLength(15)]
        public string Function { get; set; }   


        public Motorcycle motorcycle { get; set; }
        public ICollection<Supplier> Supplier { get; set; }
    }
}
