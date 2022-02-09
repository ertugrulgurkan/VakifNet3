using Catalog.Dto.Requests;
using Catalog.Entity;
using Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddData(AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                Product product = await productService.AddProductAsync(request);
                return Created("http://buradaolusturdum.com", product);
            }

            return BadRequest(ModelState);

        }


    }
}
