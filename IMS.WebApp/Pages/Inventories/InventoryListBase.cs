using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Inventories
{
    public class InventoryListBase : ComponentBase
    {
        protected string SearchTerm { get; private set; } = string.Empty;
        [Inject]
        public NavigationManager NavigationManager { get; private set; }
        private readonly string _addInventoryUrl = "addInventory";

        protected void OnSearchInventory(string searchTerm)
        {
            SearchTerm = searchTerm;
        }

        protected void AddInventory()
        {
            NavigationManager.NavigateTo(_addInventoryUrl);
        }
    }
}
