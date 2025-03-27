using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Path_Lab_DS;
using Path_Lab_ENTITY;

namespace Path_Lab_WEB
{
    public class Startup
    {
        public static string ConnectionString { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllersWithViews();

            services.AddControllersWithViews();
            //services.Configure<FormOptions>(x => x.ValueCountLimit = 100000);
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            //services.AddMvc()
            //.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            var cultureInfo = new CultureInfo("en-GB");
            //var cultureInfo = new CultureInfo("fr");
            //cultureInfo.NumberFormat.CurrencySymbol = "$";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=PathLab}/{action=Index}/{cf?}/{cfid?}/{id?}");

                //endpoints.MapControllerRoute(
                //name: "areas",
                //pattern: "{controller}/{action=Index}/{cf?}/{cfid?}/{id?}");
            });

            ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];

            DBAccess obj = new DBAccess();
            obj.SetConnectionstring(ConnectionString);
        }
    }
}
