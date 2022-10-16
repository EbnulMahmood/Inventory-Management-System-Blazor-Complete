using IMS.CoreBusiness.Entities;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class ProductItemComponentBase : ComponentBase
    {
        [Parameter]
        public Product Product { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private readonly string _editProductUrl = "/editProduct";
        private readonly string _deleteProductUrl = "/deleteProduct";

        public void EditProduct(int id)
        {
            NavigateToUrl(_editProductUrl, id);
        }

        public void DeleteProduct(int id)
        {
            NavigateToUrl(_deleteProductUrl, id);
        }

        private void NavigateToUrl(string url, int id)
        {
            NavigationManager.NavigateTo($"{url}/{id}");
        }
    }
}
