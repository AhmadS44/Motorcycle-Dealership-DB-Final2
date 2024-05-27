using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public int LocationID { get; set; }
        public int InventoryID {  get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(10)]
        [Display(Name = "First Name")]
        public string FirstName {get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(10)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(0210000000, 0219999999, ErrorMessage = "Please enter a vaild phone number (021-0000000)")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "City must be between 3 and 20 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters")]
        public string Address { get; set; }

        [Required]
        [Range(1000, 9999, ErrorMessage = "Please enter a vaild zip code (1000 - 9999)")]
        [Display(Name = "Zip")]
        public int Zip {  get; set; }


        public Location Location { get; set; }
        public Inventory Inventory { get; set; }
    }
}
