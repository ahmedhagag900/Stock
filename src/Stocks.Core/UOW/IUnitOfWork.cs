using Stocks.Core.Entities;
using Stocks.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.UOW
{
    /// <summary>
    /// unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// save the tracked changes to db
        /// </summary>
        /// <returns></returns>
        Task CompleteAsync();
        /// <summary>
        /// stock repo to manipluate the stock entity
        /// </summary>
        IStockRepository StockRepo { get; } 
    }
}
