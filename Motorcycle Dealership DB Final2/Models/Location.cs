using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Please enter a valid counry name (4-20)")]
        public string Country { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(10)]
        public string City { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 50 characters")]
        public string Address { get; set; }
        [Required]
        [Range(1000, 9999, ErrorMessage = "Please enter a valid Zip code (From 1000 - 9999) ")]
        public int Zip { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "The phone number field should have a maximum of 10 characters. ")]
        [Range(0100000000, 9999999999, ErrorMessage = "Please enter a valid phone number (021-0000000)")]
        [Display(Name = "PhoneNumber")]
        public int PhoneNumber { get; set; }


        public ICollection<Supplier> Supplier { get; set; }
    }
}
