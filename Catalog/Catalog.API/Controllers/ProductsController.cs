using Catalog.API.Filters;
using Catalog.Dto.Requests;
using Catalog.Dto.Responses;
using Catalog.Entity;
using Catalog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }
        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 60, VaryByQueryKeys = new[] { "test" })]
        public async Task<IActionResult> GetProducts()
        {

            var products = await productService.GetProducts();
            logger.LogInformation("Get request sunucuya ulaştı");
            return Ok(new { Products = products, Time = DateTime.Now });
        }

        [HttpPost]

        public async Task<IActionResult> AddData(AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                Product product = await productService.AddProductAsync(request);
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }

            return BadRequest(ModelState);

        }
        [HttpGet("{id}")]
        [AllowAnonymous]

        public async Task<IActionResult> GetProduct(int id)
        {
            ProductDetailResponse product = await productService.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();

        }
        [HttpGet("Search/{name}")]
        public async Task<IActionResult> Search(string name)
        {
            return Ok();

        }


        [ItemExists]
        [HttpPut]
        // Filter'ların çalışma sırası:
        //[Authorize]
        //[ResponseCache]
        //[Action]
        //[Exception]
        //[Result]

        public async Task<IActionResult> Update(int id, UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                ProductDetailResponse product = await productService.UpdateProduct(request);
                return Ok(product);
            }

            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        [ItemExists]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.Remove(id);
            return Ok();
        }


    }
}
