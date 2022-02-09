using Catalog.Data.DataContext;
using Catalog.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private CatalogDbContext catalogDbContext;

        public ProductRepository(CatalogDbContext catalogDbContext)
        {
            this.catalogDbContext = catalogDbContext;
        }
        public Task<Product> SearchProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetAll()
        {
            return await catalogDbContext.Products.ToListAsync();
        }

        public async Task Add(Product entity)
        {
            await catalogDbContext.Products.AddAsync(entity);
            await catalogDbContext.SaveChangesAsync();

        }
    }
}
