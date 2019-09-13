using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace ZooM.Infrastructure.Databases.NHibernate
{
    internal sealed class NHibernateRepository<TEntity> : IRepository<TEntity>
        where TEntity : DbModel
    {
        private readonly ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        public Task<TEntity> GetAsync(Guid id, bool includeSoftDeleted = false)
        {
            if (!includeSoftDeleted)
                return _session
                    .Query<TEntity>()
                    .Where(e => e.Id == id && !e.IsDeleted)
                    .FirstOrDefaultAsync();
            return _session.GetAsync<TEntity>(id);
        }

        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate,
            bool includeSoftDeleted = false)
        {
            var queryable = _session.Query<TEntity>().Where(predicate);

            if (!includeSoftDeleted) queryable = queryable.Where(e => !e.IsDeleted);
            return await queryable.ToListAsync();
        }

        public Task AddAsync(TEntity entity)
        {
            return PersistAsync(() => _session.SaveAsync(entity));
        }

        public Task UpdateAsync(TEntity entity)
        {
            return PersistAsync(() => _session.MergeAsync(entity));
        }

        public Task DeleteAsync(TEntity entity)
        {
            return PersistAsync(async () =>
            {
                var softDeletable = entity as ISoftDeletable;

                if (softDeletable is null)
                {
                    await _session.DeleteAsync(entity);
                }
                else
                {
                    softDeletable.SoftDelete();
                    await _session.MergeAsync(entity);
                }
            });
        }

        private async Task PersistAsync(Func<Task> persist)
        {
            using (var transaction = _session.BeginTransaction())
            {
                await persist();
                await transaction.CommitAsync();
            }
        }
    }
}