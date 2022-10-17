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
    public class ProductRepository : IProductRepository
    {
        private readonly IMSContext _context;

        public ProductRepository(IMSContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            if (await _context.Products.AnyAsync(x => x.Name.Contains(product.Name, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Product with same name already exists");

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return;

            product.IsActive = false;
            _context.Products.Update(product);

            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products
                .Include(x => x.ProductInventories)
                .ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<IEnumerable<Product>> ListProductsByNameAsync(string name)
        {
            return await _context.Products.Where(x => (x.Name
                .Contains(name, StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrWhiteSpace(name)) &&
                x.IsActive == true
            ).ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (await _context.Products.AnyAsync(x => x.Id != product.Id &&
                x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
                throw new Exception($"{product.Name} with same name already exists");

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
