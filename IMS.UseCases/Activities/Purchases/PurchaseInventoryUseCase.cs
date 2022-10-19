using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginIRepositories;
using IMS.UseCases.Activities.Purchases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Activities.Purchases
{
    public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
    {
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public PurchaseInventoryUseCase(IInventoryTransactionRepository inventoryTransactionRepository,
            IInventoryRepository inventoryRepository)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(string purchaseNumber, Inventory inventory,
            int quantity, string doneBy)
        {
            await _inventoryTransactionRepository
                .PurchaseAsync(purchaseNumber, inventory, quantity, inventory.Price, doneBy);
            
            inventory.Quantity += quantity;
            await _inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
