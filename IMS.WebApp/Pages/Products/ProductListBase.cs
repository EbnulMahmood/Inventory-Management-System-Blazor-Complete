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
            Products = await ViewProductsByNameUseCase.ExecuteAsync();
        }

        public void OnSearchProducts(IEnumerable<Product> products)
        {
            Products = products;
        }

        protected void NavigateToAddProduct()
        {
            NavigationManager.NavigateTo(_addProductUrl);
        }
    }
}
