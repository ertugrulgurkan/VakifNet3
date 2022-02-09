using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entity
{
   public class Product : IEntity
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? StockCount { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }      
        [NotMapped]
        public List<string> Properties { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
    }
}
