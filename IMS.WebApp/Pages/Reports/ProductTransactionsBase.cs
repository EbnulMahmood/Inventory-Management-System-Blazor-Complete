using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;
using IMS.UseCases.Reports.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IMS.WebApp.Pages.Reports
{
    public class ProductTransactionsBase : ComponentBase
    {
        protected string ProductName { get; set; } = string.Empty;
        protected DateTime? DateFrom { get; set; }
        protected DateTime? DateTo { get; set; }
        protected int ActivityTypeId { get; set; } = -1;
        private ProductTransactionType? _productTransactionType = null;
        protected IEnumerable<ProductTransaction> ProductTransactions { get; private set; }
        [Inject]
        public IListProductTransactionsUseCase ProductTransactionsUseCase { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ProductTransactions = await SearchProductsAsync();
        }

        protected async Task<IEnumerable<ProductTransaction>> SearchProductsAsync()
        {
            if (ActivityTypeId != -1)
            {
                _productTransactionType = ActivityTypeId == 1 ?
                    ProductTransactionType.ProduceProduct :
                    ProductTransactionType.SaleProduct;
            }

            ProductTransactions = await ProductTransactionsUseCase.ExecuteAsync(ProductName, DateFrom,
                DateTo, _productTransactionType);

            return ProductTransactions;
        }

        protected async Task PrintProductsAsync()
        {
            await JSRuntime.InvokeVoidAsync("print");
        }
    }
}
