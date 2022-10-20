using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginIRepositories
{
    public interface IProductTransactionRepository
    {
        Task<IEnumerable<ProductTransaction>> ListProductTransactionsAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionType);
        Task ProduceAsync(string productionNumber, Product product, int quantity,
            double price, string doneBy);
        Task SaleProductAsync(string salesOrderNumber, Product product, int quantity, double price, string doneBy);
    }
}
