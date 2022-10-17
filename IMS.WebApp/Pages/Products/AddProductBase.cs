using IMS.CoreBusiness.Entities;
using IMS.UseCases.Products.Interfaces;
using IMS.WebApp.Pages.Components.ProductsComponents;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Products
{
    public class AddProductBase : ComponentBase
    {
        [Inject]
        public IAddProductUseCase AddProductUseCase { get; private set; }
        [Inject]
        public NavigationManager NavigationManager { get; private set; }
        protected Product product;
        protected ProductInventoriesComponent? productInventoriesComponent;
        private readonly string _productsUrl = "/products";

        protected override void OnInitialized()
        {
            product = new();
        }

        protected async Task OnValidSubmit()
        {
            try
            {
                productInventoriesComponent.ProductInventories.ForEach(x =>
                {
                    x.ProductId = product.Id;
                });
                // product.ProductInventories = productInventoriesComponent.ProductInventories;
                await AddProductUseCase.ExecuteAsync(product);
            }
            catch (Exception)
            {

                throw;
            }
            NavigateToProducts();
        }
        
        protected void OnInventorySelected(List<ProductInventory> productInventories)
        {
            product.ProductInventories = productInventories;
        }

        protected void NavigateToProducts()
        {
            NavigationManager.NavigateTo(_productsUrl);
        }
    }
}
