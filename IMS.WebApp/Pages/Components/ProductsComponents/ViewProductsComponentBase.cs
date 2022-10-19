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
        private string _productNameToSearch = string.Empty;
        [Parameter]
        public EventCallback<IEnumerable<Product>> OnSearchProducts { get; set; }
        [Parameter]
        public EventCallback<Product> OnSelectProduct { get; set; }
        public string ProductNameToSearch 
        { 
            get => _productNameToSearch;
            set
            {
                _productNameToSearch = value;
                if (!string.IsNullOrWhiteSpace(_productNameToSearch) &&
                    _productNameToSearch.Length > 2)
                {
                    ViewProducts();
                }
            }
        }

        protected async Task ViewProducts()
        {
            Products = await ViewProductsByNameUseCase.ExecuteAsync(_productNameToSearch);
            await OnSearchProducts.InvokeAsync(Products);
            SelectedProduct = null;
            StateHasChanged();
        }

        protected async Task SelectProduct(Product product)
        {
            SelectedProduct = product;
            await OnSelectProduct.InvokeAsync(product);
        }
    }
}
