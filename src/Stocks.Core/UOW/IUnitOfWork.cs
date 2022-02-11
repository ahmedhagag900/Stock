using Stocks.Core.Entities;
using Stocks.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.UOW
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        IStockRepository StockRepo { get; } 
    }
}
