using IMS.CoreBusiness.Entities;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Controls
{
    public class InventoryListItemComponentBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Inventory> Inventories { get; set; } = Enumerable.Empty<Inventory>();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private readonly string _editInventoryUrl = "/editInventory";

        public void EditInventory(int id)
        {
            NavigationManager.NavigateTo($"{_editInventoryUrl}/{id}");
        }
    }
}
