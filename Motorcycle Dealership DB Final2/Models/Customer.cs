using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "First name must be between (3 - 15) characters")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Last name must be between (3 - 15) characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "The phone number field should have a maximum of 10 characters. ")]
        [Range(0100000000, 9999999999, ErrorMessage = "Please enter a valid phone number (021-0000000)")]
        [Display(Name = "PhoneNumber")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 50 characters")]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        public ICollection<PurchaseOrder> PurchaseOrder { get; set; } 
    }
}
