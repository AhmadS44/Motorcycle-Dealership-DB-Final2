using System.ComponentModel.DataAnnotations;

namespace Motorcycle_Dealership_DB_Final2.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderID { get; set; }
        public int CustomerID { get; set; }

        [Display(Name = "PurchaseDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [StringLength(25)]
        public string Model { get; set; }

        [Required]
        [Range(1000, 9999, ErrorMessage = "Please enter a vaild zip code (1000 - 9999)")]
        [Display(Name = "Zip")]
        public int Zip { get; set; }

        [Required]
        [Range(0210000000, 0219999999, ErrorMessage = "Please enter a vaild phone number (021-0000000)")]
        [Display(Name = "PhoneNumber")]
        public int PhoneNumber {  get; set; }  


        public Customer customer { get; set; }
    }
}
