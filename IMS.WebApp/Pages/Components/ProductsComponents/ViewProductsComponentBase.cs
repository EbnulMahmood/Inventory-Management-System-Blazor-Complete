using IMS.CoreBusiness.Entities;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class ViewProductsComponentBase : ComponentBase
    {
        protected IEnumerable<Product> Products { get; private set; } = Enumerable.Empty<Product>();
        public Product? SelectedProduct { get; private set; }
        [Parameter]
        public bool DisplaySearchResult { get; set; } = false;
        [Inject]
        public IViewProductsByNameUseCase ViewProductsByNameUseCase { get; private set; }
        protected string productNameToSearch = string.Empty;
        [Parameter]
        public EventCallback<IEnumerable<Product>> OnSearchProducts { get; set; }
        [Parameter]
        public EventCallback<Product> OnSelectProduct { get; set; }

        protected async Task ViewProducts()
        {
            Products = await ViewProductsByNameUseCase.ExecuteAsync(productNameToSearch);
            await OnSearchProducts.InvokeAsync(Products);
            SelectedProduct = null;
        }

        protected async Task SelectProduct(Product product)
        {
            SelectedProduct = product;
            await OnSelectProduct.InvokeAsync(product);
        }
    }
}
