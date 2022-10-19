using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginIRepositories;
using IMS.UseCases.Produces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Produces.Validations
{
    public class ValidateEnoughInventoriesForProducingUseCase : IValidateEnoughInventoriesForProducingUseCase
    {
        private readonly IProductRepository _productRepository;

        public ValidateEnoughInventoriesForProducingUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> ExecuteAsync(Product product, int quantity)
        {
            var productToValidate = await _productRepository.GetProductByIdAsync(product.Id);
            foreach (var item in productToValidate.ProductInventories)
            {
                if (item.InventoryQuantity * quantity > item.Inventory.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
