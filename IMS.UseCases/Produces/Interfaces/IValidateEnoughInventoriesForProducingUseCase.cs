using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Produces.Interfaces
{
    public interface IValidateEnoughInventoriesForProducingUseCase
    {
        Task<bool> ExecuteAsync(Product product, int quantity);
    }
}