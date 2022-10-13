using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class SearchProductComponentBase : ComponentBase
    {
        protected string productNameToSearch = string.Empty;
        [Parameter]
        public EventCallback<string> OnSearchProduct { get; set; }

        protected async Task OnSearch()
        {
            await OnSearchProduct.InvokeAsync(productNameToSearch);
        }
    }
}
