using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.Repositories
{
    /// <summary>
    /// base repo used for general operation
    /// </summary>
    /// <typeparam name="Entity">entity type</typeparam>
    public interface IBaseRepository<Entity> where Entity : class 
    {
        Task<Entity> AddAsync(Entity type);
        Task<Entity> GetByIdAsync(long id);
        Task Delete(Entity type);
        Task<IEnumerable<Entity>> GetByAsync(Expression<Func<Entity, bool>> predicte);
        Task<int> SaveAsync();
    }
}
