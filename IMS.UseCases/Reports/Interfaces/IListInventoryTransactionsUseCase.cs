using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;

namespace IMS.UseCases.Reports.Interfaces
{
    public interface IListInventoryTransactionsUseCase
    {
        Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime? dateFrom, 
            DateTime? dateTo, InventoryTransactionType? transactionType);
    }
}