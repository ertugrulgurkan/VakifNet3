using Catalog.API.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseBadwordsFilter(this IApplicationBuilder app)
        {
            app.UseMiddleware<BadWordFilterMiddlleware>();
            return app;
        }
    }
}
