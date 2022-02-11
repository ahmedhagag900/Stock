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
        Task<IEnumerable<Stock>> GetRandomStocksAsync(int numOfStocks);
    }
}
