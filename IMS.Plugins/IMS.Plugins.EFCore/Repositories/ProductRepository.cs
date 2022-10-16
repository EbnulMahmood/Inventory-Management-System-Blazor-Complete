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

        public async Task<IEnumerable<Product>> ListProductsByNameAsync(string name)
        {
            return await _context.Products.Where(x => x.Name
                .Contains(name, StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrWhiteSpace(name)
            ).ToListAsync();
        }
    }
}
