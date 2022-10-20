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
    public class ListProductTransactionsUseCase : IListProductTransactionsUseCase
    {
        private readonly IProductTransactionRepository _productTransactionRepository;

        public ListProductTransactionsUseCase(IProductTransactionRepository productTransactionRepository)
        {
            _productTransactionRepository = productTransactionRepository;
        }

        public async Task<IEnumerable<ProductTransaction>> ExecuteAsync(string productName, DateTime? dateFrom,
            DateTime? dateTo, ProductTransactionType? transactionType)
        {
            return await _productTransactionRepository.ListProductTransactionsAsync(productName, dateFrom,
                dateTo, transactionType);
        }
    }
}
