using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;
using IMS.Plugins.EFCore.Data;
using IMS.UseCases.PluginIRepositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<ProductTransaction>> ListProductTransactionsAsync(string productName, 
            DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionType)
        {
            if (dateTo.HasValue) dateTo = dateTo.Value.AddDays(1);

            var query = from productTransactions in _context.ProductTransactions
                        join product in _context.Products
                        on productTransactions.ProductId equals product.Id
                        where 
                            (string.IsNullOrWhiteSpace(productName) ||
                            product.Name.Contains(productName, StringComparison.OrdinalIgnoreCase)) &&
                            (!dateFrom.HasValue || productTransactions.TransactionDate >= dateFrom.Value.Date) &&
                            (!dateTo.HasValue || productTransactions.TransactionDate >= dateTo.Value.Date) &&
                            (!transactionType.HasValue || productTransactions.ActivityType == transactionType)
                        select productTransactions;

            return await query.Include(x => x.Product).ToListAsync();
        }

        public async Task ProduceAsync(string productionNumber, Product product, int quantity,
            double price, string doneBy)
        {
            var productToSave = await _productRepository.GetProductByIdAsync(product.Id);
            if (productToSave != null)
            {
                foreach(var item in productToSave.ProductInventories)
                {
                    int quantityBefore = item.Inventory.Quantity;

                    item.Inventory.Quantity -= quantity * item.InventoryQuantity;
                    
                    await _context.InventoryTransactions.AddAsync(new InventoryTransaction()
                    {
                        ProductionNumber = productionNumber,
                        InventoryId = item.Inventory.Id,
                        Inventory = item.Inventory,
                        QuantityBefore = quantityBefore,
                        ActivityType = InventoryTransactionType.ProduceProduct,
                        QuantityAfter = item.Inventory.Quantity,
                        TransactionDate = DateTime.Now,
                        UnitPrice = price,
                        DoneBy = doneBy,
                    });
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

        public async Task SaleProductAsync(string salesOrderNumber, Product product, 
            int quantity, double price, string doneBy)
        {
            await _context.ProductTransactions.AddAsync(new ProductTransaction()
            {
                SaleOrderNumber = salesOrderNumber,
                ProductId = product.Id,
                Product = product,
                QuantityBefore = product.Quantity,
                ActivityType= ProductTransactionType.SaleProduct,   
                QuantityAfter = product.Quantity - quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });
         
            await _context.SaveChangesAsync();
        }
    }
}
