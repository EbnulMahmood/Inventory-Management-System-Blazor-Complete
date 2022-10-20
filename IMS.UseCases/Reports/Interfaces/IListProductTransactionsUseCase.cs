using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;

namespace IMS.UseCases.Reports.Interfaces
{
    public interface IListProductTransactionsUseCase
    {
        Task<IEnumerable<ProductTransaction>> ExecuteAsync(string productName, DateTime? dateFrom, 
            DateTime? dateTo, ProductTransactionType? transactionType);
    }
}