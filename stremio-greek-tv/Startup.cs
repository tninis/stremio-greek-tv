using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using stremio_greek_tv.Helpers;
using stremio_greek_tv.Interfaces;
using stremio_greek_tv.StreamRetrievers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace stremio_greek_tv
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
            ManifestHelpers.Initialize(_env);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddMemoryCache();           
            if (_env.IsDevelopment())
            {
                services.AddSingleton<IStreamRetriever>(sp =>
                {
                    var fullPath = Path.Combine(AppContext.BaseDirectory, Constants.TVChannelsFilePath);
                    return ActivatorUtilities.CreateInstance<FileStreamRetriever>(sp, fullPath);
                });
            }
            else
            {
                services.AddSingleton<IStreamRetriever>(sp =>
                {
                    return ActivatorUtilities.CreateInstance<URLStreamRetriever>(sp, Constants.TVChannelsFileUrl);
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod());           
            
         
           
            app.UseRouting();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
