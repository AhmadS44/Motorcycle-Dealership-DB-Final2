using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class Customer
    {
        //primary key//
        public int CustomerID { get; set; }

        //First name has to have uppercase and limited to 10 characters//
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(10)]
        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        //Last name has to have uppercase and limited to 10 characters//
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(10)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //phone number needs to be a number and limited to 10 characters//
        [Required]
        [Range(0210000000, 0219999999, ErrorMessage = "Please enter a vaild phone number (021-0000000)")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        //the minimum length of the address is 5 and max is 100//
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters")]
        public string Address { get; set; }

        //must be in email format for example "jonathon@gmail.com"//
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        public ICollection<PurchaseOrder> PurchaseOrder { get; set; }

        internal static IQueryable<Customer> Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
