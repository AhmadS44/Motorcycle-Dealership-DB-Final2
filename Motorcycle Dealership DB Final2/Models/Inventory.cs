using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Inventory
    {
        //primary key//
        public int InventoryID { get; set; }
        //motorcycle foreign key//
        public int MotorcycleID { get; set; }

        //model of the motorcycle and is limited to 25 characters//
        [Required]
        [StringLength(25)]
        public string Model { get; set; }

        //phone number needs to be a number and limited to 10 characters//
        [Required]
        [Range(0210000000, 0219999999, ErrorMessage = "Please enter a vaild phone number (021-0000000)")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        //must be in email format for example "jonathon@gmail.com"//
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set;}

        //function shows the current of the model whether it is out of stock, in stock or display and is limited to 15 characters//
        [Required]
        [StringLength(15)]
        public string Function { get; set; }   


        public Motorcycle motorcycle { get; set; }
        public ICollection<Supplier> Supplier { get; set; }
    }
}
