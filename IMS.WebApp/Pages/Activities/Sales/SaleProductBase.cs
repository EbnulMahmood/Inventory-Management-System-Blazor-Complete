using IMS.CoreBusiness.Entities;
using IMS.UseCases.Activities.Sales.Interfaces;
using IMS.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Activities.Sales
{
    public class SaleProductBase : ComponentBase
    {
        protected SaleViewModel saleViewModel = new();
        protected Product? SelectedProduct { get; private set; }
        protected string Message = string.Empty;
        protected string? MessageType = null;
        [Inject]
        public ISaleProductUseCase SaleProductUseCase { get; private set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private const string _productsUrl = "/products";

        public async Task OnValidSubmit()
        {
            if (SelectedProduct.Quantity < saleViewModel.QuantityToSale)
            {
                MessageType = "danger";
                Message = $"The product quantity is not enough, only {SelectedProduct.Quantity} are available";
                return;
            }
            else
            {
                MessageType = "success";
                Message = $"{saleViewModel.QuantityToSale} {SelectedProduct.Name} soled successfully";
                await SaleProductUseCase.ExecuteAsync(saleViewModel.SalesOrderNumber, SelectedProduct,
                    saleViewModel.QuantityToSale, "Frank");
            }

            saleViewModel = new();
            SelectedProduct = null;
        }

        public void OnSelectProduct(Product product)
        {
            SelectedProduct = product;
            saleViewModel.ProductId = product.Id;
            saleViewModel.ProductName = product.Name;
            saleViewModel.ProductPrice = product.Price;
        }

        public void NavigateToProducts()
        {
            NavigateToUrl(_productsUrl);
        }

        private void NavigateToUrl(string url, int? id = null)
        {
            if (id == null) NavigationManager.NavigateTo(url);
            else NavigationManager.NavigateTo($"{url}/{id}");
        }
    }
}
