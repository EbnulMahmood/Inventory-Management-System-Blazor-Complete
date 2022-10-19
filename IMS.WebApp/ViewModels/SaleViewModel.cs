using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IMS.WebApp.ViewModels
{
    public class SaleViewModel
    {
        [Required(ErrorMessage = "The Sales Order Number field is required.")]
        [Display(Name = "Sales Order Number")]
        public string SalesOrderNumber { get; set; } = string.Empty;
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "The Product Name field is required.")]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity out of range")]
        [Display(Name = "Quantity to Sale")]
        public int QuantityToSale { get; set; }
        [Required]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "Price out of range")]
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }
    }
}
