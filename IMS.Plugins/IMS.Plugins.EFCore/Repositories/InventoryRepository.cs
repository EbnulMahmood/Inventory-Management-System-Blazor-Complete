using IMS.CoreBusiness.Entities;
using IMS.Plugins.EFCore.Data;
using IMS.UseCases.PluginIRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext _context;

        public InventoryRepository(IMSContext context)
        {
            _context = context;
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            if (await _context.Inventories.AnyAsync(x => x.Name.Contains(inventory.Name, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Inventory with same name already exists");

            await _context.Inventories.AddAsync(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
                throw new Exception("Inventory does not exist in database");

            return inventory;
        }

        public async Task<IEnumerable<Inventory>> ListInventoriesByNameAsync(string name)
        {
            return await _context.Inventories.Where(x => x.Name
                .Contains(name, StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrWhiteSpace(name)
            ).ToListAsync();
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            if (await _context.Inventories.AnyAsync(x => x.Id != inventory.Id &&
                x.Name.Equals(inventory.Name, StringComparison.OrdinalIgnoreCase)))
                throw new Exception($"{inventory.Name} with same name already exists");

            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
