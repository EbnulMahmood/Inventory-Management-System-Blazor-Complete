using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Enums;
using IMS.UseCases.Reports.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IMS.WebApp.Pages.Reports
{
    public class InventoryTransactionsBase : ComponentBase
    {
        protected string InventoryName { get; set; } = string.Empty;
        protected DateTime? DateFrom { get; set; }
        protected DateTime? DateTo { get; set; }
        protected int ActivityTypeId { get; set; } = -1;
        private InventoryTransactionType? _inventoryTransactionType = null;
        protected IEnumerable<InventoryTransaction> InventoryTransactions { get; private set; }
        [Inject]
        public IListInventoryTransactionsUseCase InventoryTransactionsUseCase { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            InventoryTransactions = await SearchInventoriesAsync();
        }

        protected async Task<IEnumerable<InventoryTransaction>> SearchInventoriesAsync()
        {
            if (ActivityTypeId != -1)
            {
                _inventoryTransactionType = ActivityTypeId == 1 ? 
                    InventoryTransactionType.PurchaseInventory :
                    InventoryTransactionType.ProduceProduct;
            }

            InventoryTransactions = await InventoryTransactionsUseCase.ExecuteAsync(InventoryName, DateFrom,
                DateTo, _inventoryTransactionType);
            
            return InventoryTransactions;
        }

        protected async Task PrintInventoriesAsync()
        {
            await JSRuntime.InvokeVoidAsync("print");
        }
    }
}
