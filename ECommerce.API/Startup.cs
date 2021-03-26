using ECommerce.API.Middlewares;
using ECommerce.Domain.Repository;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.RepositoryImplementations;
using ECommerce.Service.Abstract;
using ECommerce.Service.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ECommerce.API
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

            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:ECommerceDbContext"]);
            });
            services.AddScoped<ISmartphoneRepository, SmartphoneRepository>();
            services.AddScoped<ISmartphoneService, SmartphoneService>();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ECommerce API",
                    Description = "ECommerce API allows to perform CRUD operations",
                    Contact = new OpenApiContact
                    {
                        Name = "George Tsouvaltzis",
                        Email = string.Empty,
                        Url = new System.Uri("https://github.com/georgetsouvaltzis")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce API");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            app.UseMiddleware<RequestResponseMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
