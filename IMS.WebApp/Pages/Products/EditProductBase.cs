using IMS.CoreBusiness.Entities;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Products
{
    public class EditProductBase : ComponentBase
    {
        [Parameter]
        public int ProductId { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; private set; }
        [Inject]
        public IViewProductByIdUseCase ViewProductByIdUseCase { get; private set; }
        [Inject]
        public IEditProductUseCase EditProductUseCase { get; set; }
        public Product product;
        private readonly string _productsUrl = "/products";

        protected override async Task OnParametersSetAsync()
        {
            product = await ViewProductByIdUseCase.ExecuteAsync(ProductId);
        }

        protected async Task OnValidSubmit()
        {
            try
            {
                await EditProductUseCase.ExecuteAsync(product);
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
