using Catalog.API.Middleware;
using Catalog.Data.DataContext;
using Catalog.Data.Repositories;
using Catalog.Services;
using Catalog.Services.MappingProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Extensions;
using Catalog.API.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Catalog.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserService, UserService>();

            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<CatalogDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(CatalogProfile));
            
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
            });

            // services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOption, BasicAuthenticationHandler>("Basic",null);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(config =>
                    {
                        config.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateActor = true,
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "turkay",
                            ValidAudience = "turkay",
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Burada çok gizli bir cümlemiz var"))

                        };
                    });

            services.AddCors(co => co.AddPolicy("Allow", cp => {
                cp.AllowAnyOrigin();
                cp.AllowAnyMethod();
                cp.AllowAnyHeader();
            }));




            /*
             * http://www.turkayurkmez.com
             * https://www.turkayurkmez.com
             * http://post.turkayurkmez.com
             * http://www.turkayurkmez.com:9000
             * http://www.turkayurkmez.com/categories
             */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.Run( async(context) =>
            //{   
            //        await context.Response.WriteAsync("Test"); 
            //});

            app.Map("/test", process =>
             {
                 process.Run(async (context) =>
                 {
                     if (context.Request.Query.ContainsKey("id"))
                     {
                         await context.Response.WriteAsync($"verilen  {context.Request.Query["id"]} değeri mevcut....");
                     }
                     else
                     {
                         await context.Response.WriteAsync("Bir id olmadigi icin test yapilamadi");

                     }
                 });
             });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("Allow");

           // app.UseBadwordsFilter();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
