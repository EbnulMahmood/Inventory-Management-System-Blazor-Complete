using IMS.CoreBusiness.Entities;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Inventories
{
    public class InventoryListBase : ComponentBase
    {
        public IEnumerable<Inventory> Inventories { get; set; } = Enumerable.Empty<Inventory>();
        private readonly string _addInventoryUrl = "/addInventory";

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IViewInventoriesByNameUseCase ViewInventoriesByNameUseCase { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Inventories = await ViewInventoriesByNameUseCase.ExecuteAsync();
        }

        public void OnSearchInventories(IEnumerable<Inventory> inventories)
        {
            Inventories = inventories;
        }

        protected void NavigateToAddInventory()
        {
            NavigationManager.NavigateTo(_addInventoryUrl);
        }
    }
}
