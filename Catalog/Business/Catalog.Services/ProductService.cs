using AutoMapper;
using Catalog.Data.Repositories;
using Catalog.Dto.Requests;
using Catalog.Dto.Responses;
using Catalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository repository;
        private IMapper mapper;

        public ProductService(IProductRepository repository, IMapper mapper )
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Product> AddProductAsync(AddProductRequest request)
        {
             var product =  mapper.Map<Product>(request);

            await repository.Add(product);
            return product;
        }

        public async Task<IList<ProductSummaryDisplayResponse>> GetProducts()
        {
            var products = await repository.GetAll();
            var list = mapper.Map<List<ProductSummaryDisplayResponse>>(products);
            //List<ProductSummaryDisplayResponse> list = new List<ProductSummaryDisplayResponse>();
            //products.ToList().ForEach(pr => list.Add(new ProductSummaryDisplayResponse { Id = pr.Id, Name = pr.Name, Price = pr.Price }));

            return list;
        }
    }
}
