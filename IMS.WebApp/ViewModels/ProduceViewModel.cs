using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IMS.WebApp.ViewModels
{
    public class ProduceViewModel
    {
        [Required(ErrorMessage = "The Production Number field is required.")]
        [Display(Name = "Production Number")]
        public string ProductionNumber { get; set; } = string.Empty;
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "The Product Name field is required.")]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity out of range")]
        [Display(Name = "Quantity to Produce")]
        public int QuantityToProduce { get; set; }
        public double ProductPrice { get; set; }
    }
}
