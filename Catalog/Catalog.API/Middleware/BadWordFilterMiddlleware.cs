using Catalog.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.API.Middleware
{
    public class BadWordFilterMiddlleware
    {
        RequestDelegate next;
        public BadWordFilterMiddlleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method == "POST")
            {
                // var hasJsonContentType = httpContext.Request.HasJsonContentType();
                 
                var result = httpContext.Request.ReadFromJsonAsync(typeof(Product));
                //{

                httpContext.Items["found"] = true;
                 
                    //var isBadWord =  badWord.ToList().Contains(result.Description);
                   
                //}
            }
           
            await next.Invoke(httpContext);
           
        }
    }
}
