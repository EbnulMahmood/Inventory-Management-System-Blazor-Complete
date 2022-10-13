using IMS.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginIRepositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> ListInventoriesByNameAsync(string name);
        Task AddInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);
        Task<Inventory> GetInventoryByIdAsync(int id);
    }
}
