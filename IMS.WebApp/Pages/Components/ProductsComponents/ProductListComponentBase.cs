using IMS.CoreBusiness.Entities;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class ProductListComponentBase : ComponentBase
    {
        [Inject]
        public IViewProductsByNameUseCase ViewProductsByNameUse { get; private set; }
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        [Parameter]
        public string SearchTerm { get; set; } = string.Empty;

        protected override async Task OnParametersSetAsync()
        {
            Products = await ViewProductsByNameUse.ExecuteAsync(SearchTerm);
        }
    }
}
