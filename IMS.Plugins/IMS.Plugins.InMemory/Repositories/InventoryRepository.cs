using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory() { Id = 1, Name = "Bike Seat", Quantity = 10, Price = 200},
                new Inventory() { Id = 2, Name = "Bike Body", Quantity = 10, Price = 300},
                new Inventory() { Id = 3, Name = "Bike Weels", Quantity = 20, Price = 100},
                new Inventory() { Id = 4, Name = "Bike Pedels", Quantity = 20, Price = 500},
            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.Name.Contains(inventory.Name, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Inventory with same name already exists");

            var maxId = _inventories.Max(x => x.Id);
            inventory.Id = maxId;

            _inventories.Add(inventory);
            return Task.CompletedTask;
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            var inventory = _inventories.FirstOrDefault(x => x.Id == id);
            if (inventory == null)
                throw new Exception("Inventory does not exist in database");

            var newInventory = new Inventory()
            {
                Id = inventory.Id,
                Name = inventory.Name,
                Quantity = inventory.Quantity,
                Price = inventory.Price,
            };

            return await Task.FromResult(newInventory);
        }

        public async Task<IEnumerable<Inventory>> ListInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.Id != inventory.Id &&
                x.Name.Equals(inventory.Name, StringComparison.OrdinalIgnoreCase)))
                throw new Exception($"{inventory.Name} with same name already exists");

            var inventoryToUpdate = _inventories.FirstOrDefault(x => x.Id == inventory.Id);
            if (inventoryToUpdate == null)
                throw new Exception("Inventory does not exist in database");

            inventoryToUpdate.Name = inventory.Name;
            inventoryToUpdate.Quantity = inventory.Quantity;
            inventoryToUpdate.Price = inventory.Price;

            return Task.CompletedTask;
        }
    }
}
