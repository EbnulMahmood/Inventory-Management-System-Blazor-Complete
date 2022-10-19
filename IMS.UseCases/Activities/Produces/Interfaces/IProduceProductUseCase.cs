using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Activities.Produces.Interfaces
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy);
    }
}