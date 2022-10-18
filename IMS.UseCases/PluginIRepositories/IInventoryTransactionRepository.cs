using IMS.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginIRepositories
{
    public interface IInventoryTransactionRepository
    {
        Task PurchaseAsync(string purchaseNumber, Inventory inventory,
            int quantity, double price, string doneBy);
    }
}
