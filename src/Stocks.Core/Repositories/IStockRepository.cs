using Stocks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.Repositories
{
    public interface IStockRepository:IBaseRepository<Stock>
    {
        /// <summary>
        /// get radnom stock data
        /// </summary>
        /// <param name="numOfStocks">number of random stock</param>
        /// <returns></returns>
        Task<IEnumerable<Stock>> GetRandomStocksAsync(int numOfStocks);
    }
}
