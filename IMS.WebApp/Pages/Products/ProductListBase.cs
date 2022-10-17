using IMS.CoreBusiness.Entities;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Products
{
    public class ProductListBase : ComponentBase
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        private readonly string _addProductUrl = "/addProduct";
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IViewProductsByNameUseCase ViewProductsByNameUseCase { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadProducts();
        }

        public void OnSearchProducts(IEnumerable<Product> products)
        {
            Products = products;
        }

        public async Task OnProductDeleted()
        {
            await LoadProducts();
        }

        public async Task LoadProducts()
        {
            Products = await ViewProductsByNameUseCase.ExecuteAsync();
        }

        protected void NavigateToAddProduct()
        {
            NavigationManager.NavigateTo(_addProductUrl);
        }
    }
}
