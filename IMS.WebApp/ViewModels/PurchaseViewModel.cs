using IMS.CoreBusiness.Entities;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class PurchaseViewModel
    {
        [Required(ErrorMessage = "The Purchase Order field is required.")]
        [Display(Name = "Purchase Order")]
        public string PurchaseOrder { get; set; } = string.Empty;
        [Required]
        public int InventoryId { get; set; }
        [Required(ErrorMessage = "The Inventory Name field is required.")]
        public string InventoryName { get; set; } = string.Empty;
        [Required]
        [Range(minimum:1, maximum:int.MaxValue, ErrorMessage ="Quantity out of range")]
        [Display(Name = "Quantity to Purchase")]
        public int QuantityToPurchase { get; set; }
        public double InventoryPrice { get; set; }
    }
}
