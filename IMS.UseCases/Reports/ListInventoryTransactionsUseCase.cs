using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;
using IMS.UseCases.PluginIRepositories;
using IMS.UseCases.Reports.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Reports
{
    public class ListInventoryTransactionsUseCase : IListInventoryTransactionsUseCase
    {
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        public ListInventoryTransactionsUseCase(IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        public async Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime? dateFrom,
            DateTime? dateTo, InventoryTransactionType? transactionType)
        {
            return await _inventoryTransactionRepository.ListInventoryTransactionsAsync(inventoryName, dateFrom,
                dateTo, transactionType);
        }
    }
}
