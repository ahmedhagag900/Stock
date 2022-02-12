using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stocks.Core.Entities;
using Stocks.Core.Repositories;
using Stocks.Core.UOW;
using System;
using System.Threading.Tasks;

namespace Stocks.Infrastructure.Data.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StockDbContext _context;
        private readonly IStockRepository _stockRepo;
        public UnitOfWork(StockDbContext context, IStockRepository stockRepo)
        {
            _context = context;
            _stockRepo = stockRepo;
        }

        public IStockRepository StockRepo { get => _stockRepo; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
            //try
            //{
            //    var stratagy=_context.Database.CreateExecutionStrategy();
            //    await stratagy.ExecuteAsync(async () =>
            //    {

            //        _logger.LogInformation("Transaction Begins");
            //        await _context.BeginTransactionAsync();
            //        await _context.SaveChangesAsync();
            //        await _context.CommitTransactionAsync();
            //        _logger.LogInformation("Transaction commited");
            //    });
            //}
            //catch(Exception)
            //{

            //    _logger.LogInformation("Transaction failed rolling back");
            //    await _context.RollBackTransactionAsync();
            //    _logger.LogInformation("Transaction rolled back");
            //    throw;
            //}
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
