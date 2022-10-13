using IMS.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginIRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListProductsByNameAsync(string name);
    }
}
