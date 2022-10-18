using IMS.CoreBusiness.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Entities
{
    public class ProductTransaction
    {
        public int Id { get; set; }
        [Required]
        public int QuantityBefore { get; set; }
        [Required]
        public ProductTransactionType ActivityType { get; set; }
        [Required]
        public int QuantityAfter { get; set; }
        public string ProductionNumber { get; set; } = string.Empty;
        public string SaleOrderNumber { get; set; } = string.Empty;
        public double? UnitPrice { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string DoneBy { get; set; } = string.Empty;
        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
