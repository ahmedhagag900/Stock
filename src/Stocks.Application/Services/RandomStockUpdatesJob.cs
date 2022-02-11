using Stocks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stocks.Application.Services
{
    public class RandomStockUpdatesJob : IRecurringJobExcuter
    {
        private readonly IStockService _stockService;
        public RandomStockUpdatesJob(IStockService stockService)
        {
            _stockService = stockService;
        }
        public async Task ExceuteAsync(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                await _stockService.PerformRandomStockPriceUpdates();
                await Task.Delay(5 * 1000);
            }
        }
    }
}
