using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stocks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stocks.Web.HostedServices
{
    public class StockUpdatesBackgroundJob:BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public StockUpdatesBackgroundJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using(var scope=_serviceProvider.CreateScope())
            {
                var jobExcueter = scope.ServiceProvider.GetRequiredService<IRecurringJobExcuter>();
                await jobExcueter.ExceuteAsync(stoppingToken);
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
