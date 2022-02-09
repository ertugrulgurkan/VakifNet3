using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Dto.Requests
{
    public class AddProductRequest
    {
        [Required(ErrorMessage = "Ad boş olamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fiyat boş olamaz")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? StockCount { get; set; }
        [Required(ErrorMessage = "Kategorisini boş geçmeyin")]
        public int CategoryId { get; set; }
    }
}
