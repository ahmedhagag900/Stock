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
        Task<IEnumerable<StockModel>> GetAllStocksAsync();
        Task<IEnumerable<StockModel>> PerformRandomStockPriceUpdates();
        Task<StockDetailModel> GetStockInfoAsync(long stockId);
        Task<StockModel> UpdateStockInfoAsync(StockArgument args);
        Task<StockModel> AddStockAsync(StockArgument args);
        Task DeleteStockAsync(long stockId);
    }
}
