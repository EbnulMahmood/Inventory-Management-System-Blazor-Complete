using IMS.CoreBusiness.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Product_EnsurePriceIsGreaterThanInventoriesPrice]
        public double Price { get; set; }
        public List<ProductInventory>? ProductInventories { get; set; }

        public bool ValidatePricing()
        {
            if (ProductInventories == null || ProductInventories.Count <= 0) return true;

            double priceOfAllInventories = ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
            if (priceOfAllInventories > Price) return false;

            return true;
        }
    }
}
