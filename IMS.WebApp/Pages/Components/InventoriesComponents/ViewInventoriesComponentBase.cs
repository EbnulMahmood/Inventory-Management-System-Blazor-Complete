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
        protected IEnumerable<Inventory> Inventories { get; private set; } = Enumerable.Empty<Inventory>();
        [Parameter]
        public EventCallback<IEnumerable<Inventory>> OnSearchInventories { get; set; }

        protected async Task ViewInventories()
        {
            Inventories = await ViewInventoriesByNameUseCase.ExecuteAsync(inventoryNameToSearch);
            await OnSearchInventories.InvokeAsync(Inventories);
        }
    }
}
