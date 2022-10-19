using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginIRepositories
{
    public interface IInventoryTransactionRepository
    {
        Task<IEnumerable<InventoryTransaction>> ListInventoryTransactionsAsync(string inventoryName,
            DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType);
        Task PurchaseAsync(string purchaseNumber, Inventory inventory,
            int quantity, double price, string doneBy);
    }
}
