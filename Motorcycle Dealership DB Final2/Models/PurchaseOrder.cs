using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderID { get; set; }
        public int CustomerID { get; set; }
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [StringLength(25,ErrorMessage = "Please enter a valid model")]
        public string Model { get; set; }
        [Required]
        [Range(1000,9999, ErrorMessage = "Please enter a valid Zip code (From 1000 - 9999) ")]
        public int Zip { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "The phone number field should have a maximum of 10 characters. ")]
        [Range(0100000000, 9999999999, ErrorMessage = "Please enter a valid phone number ")]
        [Display(Name = "PhoneNumber")]
        public int PhoneNumber {  get; set; }  


        public Customer customer { get; set; }
    }
}
