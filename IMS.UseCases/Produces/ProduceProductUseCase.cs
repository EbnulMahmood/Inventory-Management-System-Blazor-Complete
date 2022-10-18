using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginIRepositories;
using IMS.UseCases.Produces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Produces
{
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IProductTransactionRepository _productTransactionRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;

        public ProduceProductUseCase(IInventoryTransactionRepository inventoryTransactionRepository,
            IProductTransactionRepository productTransactionRepository,
            IInventoryRepository inventoryRepository,
            IProductRepository productRepository)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _productTransactionRepository = productTransactionRepository;
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
        }

        public async Task ExecuteAsync(string productionNumber, Product product, int quantity,
            double price, string doneBy)
        {
            await _productTransactionRepository.ProduceAsync(productionNumber, product, quantity, price, doneBy);

            product.Quantity += quantity;
            await _productRepository.UpdateProductAsync(product);
        }
    }
}
