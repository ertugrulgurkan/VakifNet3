using Catalog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Filters
{
    public class ItemExistImplement : IAsyncActionFilter
    {
        private IProductService productService;

        public ItemExistImplement(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new NotFoundResult();
                return;
            }

            if (!(context.ActionArguments["id"] is int id))
            {
                context.Result = new BadRequestResult();
                return;
            }

            var isExist = await productService.IsProductExist(id);
            if (!isExist)
            {
                context.Result = new NotFoundObjectResult(new { message = $"{id} id'li ürün bulunamadı!" });
                return;
            }

            await next();







        }
    }
}
