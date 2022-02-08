using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products;
        public ProductService()
        {
            products = new List<Product> {
                new Product {

                Id = 1,
                Name = "Product A",
                Price = new Random().Next(1, 10),
                Description = "Description A",
                Discount = new Random().Next(1, 10) / 100 },

                  new Product {

                Id = 2,
                Name = "Product B",
                Price = new Random().Next(1, 10),
                Description = "Description B",
                Discount = new Random().Next(1, 10) / 100 },
                    new Product {

                Id = 3,
                Name = "Product C",
                Price = new Random().Next(1, 10),
                Description = "Description C",
                Discount = new Random().Next(1, 10) / 100 }
            };
        }

        public Product GetProductById(int id)
        {
            return products.Find(x => x.Id == id);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Product> GetProductsByName(string name)
        {
            return products.Where(p => p.Name.Contains(name)).ToList();
        }
    }
}
