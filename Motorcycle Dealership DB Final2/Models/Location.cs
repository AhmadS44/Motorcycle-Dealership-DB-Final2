using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Country must be between 3 and 20 characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "City must be between 3 and 20 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters")]
        public string Address { get; set; }

        [Required]
        [Range(1000, 9999, ErrorMessage = "Please enter a vaild zip code (1000 - 9999)")]
        [Display(Name = "Zip")]
        public int Zip { get; set; }

        [Required]
        [Range(0210000000, 0219999999, ErrorMessage = "Please enter a vaild phone number (021-0000000)")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }


        public ICollection<Supplier> Supplier { get; set; }
    }
}
