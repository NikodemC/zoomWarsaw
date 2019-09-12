using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ZooM.Infrastructure.Databases
{
    internal interface IRepository<TDbModel> where TDbModel : DbModel
    {
        Task<TDbModel> GetAsync(Guid id, bool includeSoftDeleted = false);
        Task<IEnumerable<TDbModel>> SearchAsync(Expression<Func<TDbModel, bool>> predicate, bool includeSoftDeleted = false);
        Task AddAsync(TDbModel entity);
        Task UpdateAsync(TDbModel entity);
        Task DeleteAsync(TDbModel entity);
    }
}
