using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class PurchaseOrder
    {
        //primary key//
        public int PurchaseOrderID { get; set; }
        //foreign key for customer//
        public int CustomerID { get; set; }

        //this is the date of the purchase//
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        //model of the motorcycle and is limited to 25 characters//
        [Required]
        [StringLength(25)]
        public string Model { get; set; }

        //zip of the location has to be in the range of 1000 - 9999//
        [Required]
        [Range(1000, 9999, ErrorMessage = "Please enter a vaild zip code (1000 - 9999)")]
        [Display(Name = "Zip")]
        public int Zip { get; set; }

        //phone number for contact about order, phone number needs to be a number and limited to 10 characters//
        [Required]
        [Range(0210000000, 0219999999, ErrorMessage = "Please enter a vaild phone number (021-0000000)")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber {  get; set; }  


        public Customer customer { get; set; }
    }
}
