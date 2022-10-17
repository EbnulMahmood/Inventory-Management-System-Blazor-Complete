using IMS.CoreBusiness.Entities;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.InventoriesComponents
{
    public class ViewInventoriesComponentBase : ComponentBase
    {
        [Inject]
        public IViewInventoriesByNameUseCase ViewInventoriesByNameUseCase { get; private set; }
        protected string inventoryNameToSearch = string.Empty;
        public string? InventoryNameToSearch 
        {
            get => inventoryNameToSearch;
            set
            {
                inventoryNameToSearch = value;
                if (!string.IsNullOrWhiteSpace(inventoryNameToSearch) &&
                    inventoryNameToSearch.Length > 2)
                {
                    ViewInventories();
                }
            }
        }
        protected IEnumerable<Inventory>? Inventories { get; private set; }
        [Parameter]
        public EventCallback<IEnumerable<Inventory>> OnSearchInventories { get; set; }
        [Parameter]
        public EventCallback<Inventory> OnSelectInventory { get; set; }
        [Parameter]
        public bool DisplaySearchResult { get; set; } = false;
        public Inventory? SelectedInventory { get; private set; }

        protected async Task ViewInventories()
        {
            Inventories = await ViewInventoriesByNameUseCase.ExecuteAsync(inventoryNameToSearch);
            await OnSearchInventories.InvokeAsync(Inventories);
            SelectedInventory = null;
            StateHasChanged();
        }

        protected async Task SelectInventory(Inventory inventory)
        {
            SelectedInventory = inventory;
            await OnSelectInventory.InvokeAsync(inventory);
        }
    }
}
