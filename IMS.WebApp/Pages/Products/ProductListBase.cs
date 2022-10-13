using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Products
{
    public class ProductListBase : ComponentBase
    {
        protected string SearchTerm { get; private set; } = string.Empty;
        [Inject]
        public NavigationManager NavigationManager { get; private set; }
        private readonly string _addProductUrl = "addProduct";

        protected void OnSearchProduct(string searchTerm)
        {
            SearchTerm = searchTerm;
        }

        protected void AddProduct()
        {
            NavigationManager.NavigateTo(_addProductUrl);
        }
    }
}
