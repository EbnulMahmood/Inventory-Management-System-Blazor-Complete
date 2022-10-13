using IMS.CoreBusiness.Entities;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class ProductsListItemComponentBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private readonly string _editProductUrl = "/editProduct";

        public void EditProduct(int id)
        {
            NavigationManager.NavigateTo($"{_editProductUrl}/{id}");
        }
    }
}
