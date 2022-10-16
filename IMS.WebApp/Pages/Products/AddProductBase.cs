using IMS.CoreBusiness.Entities;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Products
{
    public class AddProductBase : ComponentBase
    {
        [Inject]
        public IAddProductUseCase AddProductUseCase { get; private set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected Product product;
        private readonly string _productsUrl = "/products";

        protected override void OnInitialized()
        {
            product = new();
        }

        protected async Task OnValidSubmit()
        {
            try
            {
                await AddProductUseCase.ExecuteAsync(product);
            }
            catch (Exception)
            {

                throw;
            }
            NavigateToProducts();
        }
 
        protected void NavigateToProducts()
        {
            NavigationManager.NavigateTo(_productsUrl);
        }
    }
}
