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

        public async Task<Product> GetById(int id)
        {
            var product = await catalogDbContext.Products.FindAsync(id);
            return product;

        }

        public async Task<Product> Update(Product product)
        {
            catalogDbContext.Products.Update(product);
            await catalogDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> IsEntityExists(int id)
        {
           return await catalogDbContext.Products.AnyAsync(x => x.Id == id);
        }

        public async Task Delete(int id)
        {
            var product = await catalogDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            catalogDbContext.Products.Remove(product);
            await catalogDbContext.SaveChangesAsync();

        }
    }
}
