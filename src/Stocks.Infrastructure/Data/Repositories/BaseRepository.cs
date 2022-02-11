using Microsoft.EntityFrameworkCore;
using Stocks.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Infrastructure.Data.Repositories
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity:class
    {
        protected readonly StockDbContext _context;
        protected readonly DbSet<Entity> _dbSet;
        public BaseRepository(StockDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }

        public async Task<Entity> AddAsync(Entity type)
        {
            var result = await _dbSet.AddAsync(type);
            return result.Entity;
        }

        public Task Delete(Entity type)
        {
            _dbSet.Remove(type);
            return Task.CompletedTask;
        }

        public virtual async Task<IEnumerable<Entity>> GetByAsync(Expression<Func<Entity, bool>> predicte)
        {
            var result=await _dbSet.Where(predicte).ToListAsync();
            return result;
        }

        public virtual async Task<Entity> GetByIdAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<int> SaveAsync()
        {
            var changesCount = await _context.SaveChangesAsync();
            return changesCount;
        }


    }
}
