using System;
using System.Threading.Tasks;
using ZooM.Core.Entitites;
using ZooM.Core.Repositories;
using ZooM.Infrastructure.Databases;
using ZooM.Infrastructure.Databases.NHibernate.Entities;
using ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions;

namespace ZooM.Infrastructure.Repositories
{
    internal class AnimalActionDatabaseRepository : IAnimalActionRepository
    {
        private readonly IRepository<AnimalActionEntity> _repository;

        public AnimalActionDatabaseRepository(IRepository<AnimalActionEntity> repository)
            => _repository = repository;

        public async Task<AnimalAction> GetAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            return entity?.AsAnimalAction();
        }

        public Task AddAsync(AnimalAction animalAction)
            => _repository.AddAsync(animalAction.AsEntity());

        public Task UpdateAsync(AnimalAction animalAction)
            => _repository.UpdateAsync(animalAction.AsEntity());

        public Task DeleteAsync(AnimalAction animalAction)
            => _repository.DeleteAsync(animalAction.AsEntity());
    }
}
