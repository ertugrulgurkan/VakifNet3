using Catalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Repositories
{
   public interface IProductRepository: IRepository<Product>
    {
        Task<Product> SearchProductsByName(string name);
    }
}
