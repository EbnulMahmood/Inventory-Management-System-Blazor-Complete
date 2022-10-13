using IMS.CoreBusiness.Entities;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.ProductsComponents
{
    public class ProductsListItemComponentBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    }
}
