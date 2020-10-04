using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocApi.Models;
using DocApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DocApi
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
            // The configuration instance to which the appsettings.json file's DocumentstoreDatabaseSettings section 
            // binds is registered in the Dependency Injection (DI) container. 
            // For example, a DocumentstoreDatabaseSettings object's ConnectionString property is populated with the 
            // DocumentstoreDatabaseSettings:ConnectionString property in appsettings.json
            // requires using Microsoft.Extensions.Options
            services.Configure<DocumentstoreDatabaseSettings>(
                Configuration.GetSection(nameof(DocumentstoreDatabaseSettings)));

            //The IDocumentstoreDatabaseSettings interface is registered in DI with a singleton service lifetime.
            //When injected, the interface instance resolves to a DocumentstoreDatabaseSettings object.
            services.AddSingleton<IDocumentstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DocumentstoreDatabaseSettings>>().Value);

            // The DocumentService class is registered with DI to support constructor injection in consuming classes. 
            // The singleton service lifetime is most appropriate because BookService takes a direct dependency on MongoClient. 
            // Per the official Mongo Client reuse guidelines, MongoClient should be registered in DI with a singleton service lifetime.
            services.AddSingleton<DocumentService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
