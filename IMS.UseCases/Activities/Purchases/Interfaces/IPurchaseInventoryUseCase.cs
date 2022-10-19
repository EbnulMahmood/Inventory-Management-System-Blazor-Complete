using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Activities.Purchases.Interfaces
{
    public interface IPurchaseInventoryUseCase
    {
        Task ExecuteAsync(string purchaseNumber, Inventory inventory,
            int quantity, string doneBy);
    }
}