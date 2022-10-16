using IMS.CoreBusiness.Entities;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class ProductInventoriesComponentBase : ComponentBase
    {
        public IEnumerable<Inventory> Inventories { get; private set; }
        protected void OnSelectInventory(Inventory inventory)
        {

        }
    }
}
