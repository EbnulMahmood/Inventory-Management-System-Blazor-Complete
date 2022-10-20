using IMS.CoreBusiness.Entities;
using IMS.UseCases.Activities.Purchases.Interfaces;
using IMS.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Activities.Purchases
{
    [Authorize]
    public class PurchaseInventoryBase : ComponentBase
    {
        [Inject]
        public IPurchaseInventoryUseCase PurchaseInventoryUseCase { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected PurchaseViewModel purchaseViewModel = new();
        protected Inventory? SelectedInventory { get; private set; }
        private const string _inventoriesUrl = "/inventories";

        public void OnSelectInventory(Inventory inventory)
        {
            SelectedInventory = inventory;
            purchaseViewModel.InventoryId = inventory.Id;
            purchaseViewModel.InventoryName = inventory.Name;
            purchaseViewModel.InventoryPrice = inventory.Price;
        }

        protected async Task OnValidSubmit()
        {
            await PurchaseInventoryUseCase.ExecuteAsync(purchaseViewModel.PurchaseOrder, SelectedInventory,
                purchaseViewModel.QuantityToPurchase, "Frank");

            purchaseViewModel = new();
            SelectedInventory = null;
        }

        public void NavigateToInventories()
        {
            NavigateToUrl(_inventoriesUrl);
        }

        private void NavigateToUrl(string url, int? id = null)
        {
            if (id == null) NavigationManager.NavigateTo(url);
            else NavigationManager.NavigateTo($"{url}/{id}");
        }
    }
}
