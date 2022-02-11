using Stocks.Core.Entities;
using Stocks.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Stocks.Infrastructure.Data.Repositories
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(StockDbContext context):base(context)
        {
                
        }
        public override async Task<IEnumerable<Stock>> GetByAsync(Expression<Func<Stock, bool>> predicte)
        {
           return await _dbSet.Include(x => x.StockPrices).Where(predicte).ToListAsync();
        }

        public override async Task<Stock> GetByIdAsync(long id)
        {
            return await _dbSet.Include(x => x.StockPrices).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async  Task<IEnumerable<Stock>> GetRandomStocksAsync(int numOfStocks)
        {
            var result = await _dbSet.OrderBy(x => Guid.NewGuid()).Take(numOfStocks).ToListAsync();
            return result;
        }
    }
}
