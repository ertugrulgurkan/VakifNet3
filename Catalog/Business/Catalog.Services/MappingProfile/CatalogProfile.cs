using AutoMapper;
using Catalog.Dto.Requests;
using Catalog.Dto.Responses;
using Catalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services.MappingProfile
{
   public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<Product, ProductSummaryDisplayResponse>();
            CreateMap<AddProductRequest, Product>();

        }
    }
}
