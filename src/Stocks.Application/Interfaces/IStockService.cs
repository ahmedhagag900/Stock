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
        /// <summary>
        /// get all persisted stocks
        /// </summary>
        /// <returns>list of stockModel</returns>
        Task<IEnumerable<StockIndexModel>> GetAllStocksAsync();

        /// <summary>
        /// perform random updates on stock prices
        /// </summary>
        /// <returns>list of stockModel</returns>
        Task<IEnumerable<StockIndexModel>> PerformRandomStockPriceUpdates();

        /// <summary>
        /// get specific stock information
        /// </summary>
        /// <param name="stockId"> stock id</param>
        /// <returns></returns>
        Task<StockDetailModel> GetStockInfoAsync(long stockId);
        /// <summary>
        /// update specific stock info
        /// </summary>
        /// <param name="args">stock arguments to be uptaded</param>
        /// <returns></returns>
        Task<StockIndexModel> UpdateStockInfoAsync(StockArgument args);
        /// <summary>
        /// add new stock 
        /// </summary>
        /// <param name="args">stock arguments to be added</param>
        /// <returns></returns>
        Task<StockIndexModel> AddStockAsync(StockArgument args);
        /// <summary>
        /// delete specific stock
        /// </summary>
        /// <param name="stockId">stock id</param>
        /// <returns></returns>
        Task DeleteStockAsync(long stockId);
    }
}
