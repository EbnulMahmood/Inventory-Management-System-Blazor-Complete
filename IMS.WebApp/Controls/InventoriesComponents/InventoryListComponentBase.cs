using IMS.CoreBusiness.Entities;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Controls
{
    public class InventoryListComponentBase : ComponentBase
    {
        [Inject]
        public IViewInventoriesByNameUseCase ViewInventoriesByNameUse { get; private set; }
        public IEnumerable<Inventory> Inventories { get; set; } = Enumerable.Empty<Inventory>();
        [Parameter]
        public string SearchTerm { get; set; } = string.Empty;

        protected override async Task OnParametersSetAsync()
        {
            Inventories = await ViewInventoriesByNameUse.ExecuteAsync(SearchTerm);
        }
    }
}
