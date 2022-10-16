using IMS.CoreBusiness.Entities;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Inventories
{
    public class AddInventoryBase : ComponentBase
    {
        [Inject]
        public IAddInventoryUseCase AddInventoryUseCase { get; private set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected Inventory inventory;
        private readonly string _inventoriesUrl = "/inventories";

        protected override void OnInitialized()
        {
            inventory = new();
        }

        protected async Task OnValidSubmit()
        {
            try
            {
                await AddInventoryUseCase.ExecuteAsync(inventory);
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
