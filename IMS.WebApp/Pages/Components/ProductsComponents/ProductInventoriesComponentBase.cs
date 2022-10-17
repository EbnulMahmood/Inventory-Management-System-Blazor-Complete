using IMS.CoreBusiness.Entities;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class ProductInventoriesComponentBase : ComponentBase
    {
        [Parameter]
        public EventCallback<List<ProductInventory>> OnInventorySelected { get; set; }
        [Parameter]
        public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
        protected async Task OnInventoryQtyChanged()
        {
            await OnInventorySelected.InvokeAsync(ProductInventories);
        }

        protected async Task OnSelectInventory(Inventory inventory)
        {
            if (!ProductInventories.Any(x => x.Inventory.Name.Equals(inventory.Name,
                StringComparison.OrdinalIgnoreCase)))
            {
                ProductInventories.Add(new ProductInventory { InventoryId = inventory.Id, Inventory = inventory });
            }
            await OnInventorySelected.InvokeAsync(ProductInventories);
        }

        protected void RemoveInventory(ProductInventory productInventory)
        {
            ProductInventories.Remove(productInventory);
        }
    }
}
