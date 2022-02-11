using Microsoft.Extensions.DependencyInjection;
using Stocks.Core.Repositories;
using Stocks.Core.UOW;
using Stocks.Infrastructure.Data;
using Stocks.Infrastructure.Data.Repositories;
using Stocks.Infrastructure.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Infrastructure.IoC
{
    public static class StockInfrastructureIoC
    {
        public static void ConfigureInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<StockDbContextSeed>();
        }

    }
}
