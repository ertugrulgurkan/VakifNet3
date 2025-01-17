﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Dto.Requests
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? StockCount { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
