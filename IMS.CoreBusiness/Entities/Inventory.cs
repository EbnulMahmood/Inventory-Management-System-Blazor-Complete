using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage ="Quantity must be greater than 0")]
        public int Quantity { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }
    }
}
