using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Activities.Produces.Interfaces
{
    public interface IValidateEnoughInventoriesForProducingUseCase
    {
        Task<bool> ExecuteAsync(Product product, int quantity);
    }
}