using IMS.CoreBusiness.Entities;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class ViewProductsComponentBase : ComponentBase
    {
        [Inject]
        public IViewProductsByNameUseCase ViewProductsByNameUseCase { get; private set; }
        protected string productNameToSearch = string.Empty;
        protected IEnumerable<Product> Products { get; private set; } = Enumerable.Empty<Product>();
        [Parameter]
        public EventCallback<IEnumerable<Product>> OnSearchProducts { get; set; }

        protected async Task ViewProducts()
        {
            Products = await ViewProductsByNameUseCase.ExecuteAsync(productNameToSearch);
            await OnSearchProducts.InvokeAsync(Products);
        }
    }
}
