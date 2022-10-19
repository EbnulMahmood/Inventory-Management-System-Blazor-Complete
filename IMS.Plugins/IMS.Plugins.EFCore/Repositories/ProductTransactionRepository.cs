using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;
using IMS.Plugins.EFCore.Data;
using IMS.UseCases.PluginIRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore.Repositories
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private readonly IMSContext _context;
        private readonly IProductRepository _productRepository;

        public ProductTransactionRepository(IMSContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task ProduceAsync(string productionNumber, Product product, int quantity,
            double price, string doneBy)
        {
            var productToSave = await _productRepository.GetProductByIdAsync(product.Id);
            if (productToSave != null)
            {
                foreach(var item in productToSave.ProductInventories)
                {
                    item.Inventory.Quantity -= quantity * item.InventoryQuantity;
                }
            }

            await _context.ProductTransactions.AddAsync(new ProductTransaction()
            {
                ProductionNumber = productionNumber,
                ProductId = product.Id,
                Product = product,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = product.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            await _context.SaveChangesAsync();
        }
    }
}
