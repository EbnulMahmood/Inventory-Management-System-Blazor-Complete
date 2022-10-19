using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Sales.Interfaces
{
    public interface ISaleProductUseCase
    {
        Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy);
    }
}