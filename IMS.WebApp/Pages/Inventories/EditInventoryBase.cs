using IMS.CoreBusiness.Entities;
using IMS.UseCases.Inventories;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Inventories
{
    public class EditInventoryBase : ComponentBase
    {
        [Parameter]
        public int InventoryId { get; set; }
        [Inject]
        public IViewInventoryByIdUseCase ViewInventoryByIdUseCase { get; private set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IEditInventoryUseCase EditInventoryUseCase { get; set; }
        protected Inventory inventory = new();
        private readonly string _inventoriesUrl = "/inventories";

        protected override async Task OnParametersSetAsync()
        {
            inventory = await ViewInventoryByIdUseCase.ExecuteAsync(InventoryId);
        }

        protected async Task SaveInventory()
        {
            try
            {
                await EditInventoryUseCase.ExecuteAsync(inventory);
            }
            catch (Exception)
            {

                throw;
            }
            NavigateToInventories();
        }

        protected void NavigateToInventories()
        {
            NavigationManager.NavigateTo(_inventoriesUrl);
        }
    }
}
