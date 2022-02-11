using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Dto.Responses
{
  public class ProductDetailResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? StockCount { get; set; }       
        public int CategoryId { get; set; }       
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
       
    }
}
