using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Stocks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Infrastructure.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options):base(options)
        { }
        public IDbContextTransaction TransactionBehavior { get; private set; }
        public async Task BeginTransactionAsync()
        {
            TransactionBehavior = TransactionBehavior ?? await Database.BeginTransactionAsync();
        }
        public async Task CommitTransactionAsync()
        {
            try
            {
                await TransactionBehavior?.CommitAsync();
            }
            finally
            {
                if (TransactionBehavior != null)
                {
                    TransactionBehavior.Dispose();
                    TransactionBehavior = null;
                }
            }
        }
        public async Task RollBackTransactionAsync()
        {
            try
            {
                await TransactionBehavior?.RollbackAsync();
            }
            finally
            {
                if (TransactionBehavior != null)
                {
                    TransactionBehavior.Dispose();
                    TransactionBehavior = null;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
