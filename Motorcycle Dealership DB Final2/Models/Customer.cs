using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(10)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The phone number field should have a maximum of 10 characters.")]
        [Display(Name = "PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        public ICollection<PurchaseOrder> PurchaseOrder { get; set; } 
    }
}
