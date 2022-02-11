using Microsoft.Extensions.DependencyInjection;
using Stocks.Application.Interfaces;
using Stocks.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.IoC
{
    public static class StockApplicationIoC
    {
        public static void ConfigureApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IRecurringJobExcuter, RandomStockUpdatesJob>();
        }
    }
}
