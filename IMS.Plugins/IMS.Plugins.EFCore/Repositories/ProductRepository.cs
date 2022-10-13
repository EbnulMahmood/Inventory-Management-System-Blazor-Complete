using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginIRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<IEnumerable<Product>> ListProductsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
