using System;
using System.Threading.Tasks;
using ZooM.Core.Entitites;
using ZooM.Core.Repositories;
using ZooM.Infrastructure.Databases;
using ZooM.Infrastructure.Databases.NHibernate.Entities;
using ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions;

namespace ZooM.Infrastructure.Repositories
{
    internal class AreaDatabaseRepository : IAreaRepository
    {
        private readonly IRepository<AreaEntity> _repository;

        public AreaDatabaseRepository(IRepository<AreaEntity> repository)
            => _repository = repository;

        public async Task<Area> GetAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            return entity?.AsArea();
        }

        public Task AddAsync(Area area)
            => _repository.AddAsync(area.AsEntity());

        public Task UpdateAsync(Area area)
            => _repository.UpdateAsync(area.AsEntity());

        public Task DeleteAsync(Area area)
            => _repository.DeleteAsync(area.AsEntity());
    }
}
