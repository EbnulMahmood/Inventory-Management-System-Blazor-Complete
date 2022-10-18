using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;
using IMS.Plugins.EFCore.Data;
using IMS.UseCases.PluginIRepositories;
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
