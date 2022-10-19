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
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly IMSContext _context;

        public InventoryTransactionRepository(IMSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryTransaction>> ListInventoryTransactionsAsync(string inventoryName, 
            DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType)
        {
            var query = from inventoryTransaction in _context.InventoryTransactions
                        join inventory in _context.Inventories
                        on inventoryTransaction.InventoryId equals inventory.Id
                        where (string.IsNullOrWhiteSpace(inventoryName) ||
                        inventory.Name.Contains(inventoryName, StringComparison.OrdinalIgnoreCase)) &&
                        (!dateFrom.HasValue || inventoryTransaction.TransactionDate >= dateFrom) &&
                        (!dateTo.HasValue || inventoryTransaction.TransactionDate >= dateTo) &&
                        (!transactionType.HasValue || inventoryTransaction.ActivityType == transactionType)
                        select inventoryTransaction;

            return await query.ToListAsync();
        }

        public async Task PurchaseAsync(string purchaseNumber, Inventory inventory,
            int quantity, double price, string doneBy)
        {
            await _context.InventoryTransactions.AddAsync(new InventoryTransaction()
            {
                ProductionNumber = purchaseNumber,
                InventoryId = inventory.Id,
                Inventory = inventory,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QuantityAfter = inventory.Quantity + quantity,
                TransactionDate = DateTime.Now,
                UnitPrice = price,
                DoneBy = doneBy,
            });

            await _context.SaveChangesAsync();
        }
    }
}
