using IMS.CoreBusiness.Entities;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class InventoryItemComponentBase : ComponentBase
    {
        [Parameter]
        public Inventory Inventory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private readonly string _editInventoryUrl = "/editInventory";
        private readonly string _deleteInventoryUrl = "/deleteInventory";

        public void EditInventory(int id)
        {
            NavigateToUrl(_editInventoryUrl, id);
        }

        private void NavigateToUrl(string url, int id)
        {
            NavigationManager.NavigateTo($"{url}/{id}");
        }
    }
}
