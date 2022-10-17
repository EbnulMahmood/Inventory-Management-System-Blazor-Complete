using IMS.CoreBusiness.Entities;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class ProductItemComponentBase : ComponentBase
    {
        [Parameter]
        public Product Product { get; set; }
        [Parameter]
        public EventCallback OnProductDeleted { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IDeleteProductUseCase DeleteProductUseCase { get; set; }
        private const string _editProductUrl = "/editProduct";
        private const string _productsUrl = "/products";

        public void EditProduct(int id)
        {
            NavigateToUrl(_editProductUrl, id);
        }

        public async Task DeleteProduct(int id)
        {
            await DeleteProductUseCase.ExecuteAsync(id);
            await OnProductDeleted.InvokeAsync();
            NavigateToUrl(_productsUrl);
        }

        private void NavigateToUrl(string url, int? id = null)
        {
            if (id == null) NavigationManager.NavigateTo(url);
            else NavigationManager.NavigateTo($"{url}/{id}");
        }
    }
}
