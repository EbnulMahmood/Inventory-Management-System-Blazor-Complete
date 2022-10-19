using IMS.CoreBusiness.Entities;
using IMS.UseCases.Produces.Interfaces;
using IMS.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Produces
{
    public class ProduceProductBase : ComponentBase
    {
        protected ProduceViewModel produceViewModel = new();
        protected Product? SelectedProduct { get; private set; }
        protected string Message = string.Empty;
        protected string? MessageType = null;
        [Inject]
        public IProduceProductUseCase ProduceProductUseCase { get; private set; }
        [Inject]
        public IValidateEnoughInventoriesForProducingUseCase ValidateEnoughInventoriesForProducingUseCase
            { get; private set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private const string _productsUrl = "/products";

        public async Task OnValidSubmit()
        {
            if (!await ValidateEnoughInventoriesForProducingUseCase
                .ExecuteAsync(SelectedProduct, produceViewModel.QuantityToProduce))
            {
                MessageType = "danger";
                Message = $"The inventories are not enough for producing {SelectedProduct.Name}" +
                    $" X {produceViewModel.QuantityToProduce} times";
                return;
            }
            else
            {
                MessageType = "success";
                Message = $"{SelectedProduct.Name} produced successfully {produceViewModel.QuantityToProduce} times";
                await ProduceProductUseCase.ExecuteAsync(produceViewModel.ProductionNumber, SelectedProduct,
                    produceViewModel.QuantityToProduce, "Frank");
            }

            produceViewModel = new();
            SelectedProduct = null;
        }

        public void OnSelectProduct(Product product)
        {
            SelectedProduct = product;
            produceViewModel.ProductId = product.Id;
            produceViewModel.ProductName = product.Name;
            produceViewModel.ProductPrice = product.Price;
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
