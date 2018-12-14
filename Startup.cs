using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using nucleocs.Models;
using nucleocs.Data;
using nucleocs.Data.Repositories;
using nucleocs.Data.Repositories.Interfaces;
using nucleocs.Services;
using nucleocs.Services.Interfaces;

namespace nucleocs
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
            services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll",
                        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()                        
                        );                    
                });
            
            var sqlConnection = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<NucleoContext>(opt => opt.UseSqlServer(sqlConnection));
            services.AddDbContext<NucleoContext>(opt => opt.UseInMemoryDatabase("debug"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<ICategoryRepository, CategoryRepository>();            
            services.AddTransient<IFinishingRepository, FinishingRepository>();
            services.AddTransient<IMaterialRepository, MaterialRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IFinishingService, FinishingService>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
