using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Produces.Interfaces
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy);
    }
}