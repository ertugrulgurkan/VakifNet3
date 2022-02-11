using Catalog.Dto.Requests;
using Catalog.Dto.Responses;
using Catalog.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public interface IProductService
    {
        //YAGNI: You Ain't Gonna Need it: İhtiyacın yoksa yazma!
        Task<IList<ProductSummaryDisplayResponse>> GetProducts();      
        Task<Product> AddProductAsync(AddProductRequest request);
        Task<ProductDetailResponse> GetProduct(int id);
        Task<ProductDetailResponse> UpdateProduct(UpdateProductRequest request);

        Task<bool> IsProductExist(int id);
        Task Remove(int id);
    }

}
