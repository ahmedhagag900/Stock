using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stocks.Application.Interfaces;
using Stocks.Application.IoC;
using Stocks.Application.Services;
using Stocks.Infrastructure.Data;
using Stocks.Infrastructure.IoC;
using Stocks.Web.HostedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stocks.Application.SignalR;
using Stocks.Core.UOW;
using Stocks.Web.Middlewares;

namespace Stocks.Web
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
            var connectionString = Configuration.GetValue<string>("ConnectionString");
            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<StockDbContext>(configs =>
            {
                configs.UseSqlServer(connectionString, sqlOpt =>
                 {
                     sqlOpt.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                 });
            });
            services.AddSignalR(config => config.EnableDetailedErrors = true);
            services.AddAutoMapper(typeof(IStockService).Assembly);
            services.ConfigureApplicationDependencies();
            services.ConfigureInfrastructureDependencies();
            services.AddHostedService<StockUpdatesBackgroundJob>();
            services.AddControllersWithViews();


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

            app.UseMiddleware<TransactionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Stock}/{action=Index}/{id?}");
                endpoints.MapHub<StockHub>("/stockHub");
            });
        }
    }
}
