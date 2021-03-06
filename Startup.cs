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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PSMSWebApi
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
            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
            }));
            services.AddControllers().AddNewtonsoftJson();
            // services.AddControllers().AddNewtonsoftJson(
            //     options =>
            //     {
            //     options.SerializerSettings.DateTimeZoneHandling
            // = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            // )};

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                options.SerializerSettings.DateFormatString = "dd/MM/yyyy HH':'mm";
            });

            services.AddControllersWithViews().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

           
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
