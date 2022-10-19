using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginIRepositories;
using IMS.UseCases.Activities.Sales.Interfaces;

namespace IMS.UseCases.Activities.Sales
{
    public class SaleProductUseCase : ISaleProductUseCase
    {
        private readonly IProductTransactionRepository _productTransactionRepository;
        private readonly IProductRepository _productRepository;

        public SaleProductUseCase(IProductTransactionRepository productTransactionRepository,
            IProductRepository productRepository)
        {
            _productTransactionRepository = productTransactionRepository;
            _productRepository = productRepository;
        }

        public async Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy)
        {
            await _productTransactionRepository.SaleProductAsync(salesOrderNumber, product, quantity,
                product.Price, doneBy);

            product.Quantity -= quantity;
            await _productRepository.UpdateProductAsync(product);
        }
    }
}
