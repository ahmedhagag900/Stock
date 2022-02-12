using Microsoft.AspNetCore.SignalR;
using Stocks.Application.Interfaces;
using Stocks.Application.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Stocks.Application.Services
{
    public class RandomStockUpdatesJob : IRecurringJobExcuter
    {
        private readonly IStockService _stockService;
        private readonly IHubContext<StockHub,IStockHub> _hubContext;
        public RandomStockUpdatesJob(IStockService stockService,IHubContext<StockHub,IStockHub> hubContext)
        {
            _stockService = stockService;
            _hubContext = hubContext;
        }
        public async Task ExceuteAsync(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                var stockUpdates = await _stockService.PerformRandomStockPriceUpdates();
                await _hubContext.Clients.All.StockUpdates(stockUpdates);
                await Task.Delay(50 * 1000);
            }
        }
    }
}
