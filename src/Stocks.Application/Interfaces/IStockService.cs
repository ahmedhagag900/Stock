using Stocks.Application.Arguments;
using Stocks.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<StockIndexModel>> GetAllStocksAsync();
        Task<IEnumerable<StockIndexModel>> PerformRandomStockPriceUpdates();
        Task<StockDetailModel> GetStockInfoAsync(long stockId);
        Task<StockIndexModel> UpdateStockInfoAsync(StockArgument args);
        Task<StockIndexModel> AddStockAsync(StockArgument args);
        Task DeleteStockAsync(long stockId);
    }
}
