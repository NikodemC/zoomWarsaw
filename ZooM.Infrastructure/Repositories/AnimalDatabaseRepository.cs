using System;
using System.Threading.Tasks;
using ZooM.Core.Entitites;
using ZooM.Core.Repositories;
using ZooM.Infrastructure.Databases;
using ZooM.Infrastructure.Databases.NHibernate.Entities;
using ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions;

namespace ZooM.Infrastructure.Repositories
{
    internal class AnimalDatabaseRepository : IAnimalRepository
    {
        private readonly IRepository<AnimalEntity> _repository;

        public AnimalDatabaseRepository(IRepository<AnimalEntity> repository)
            => _repository = repository;

        public async Task<Animal> GetAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            return entity?.AsAnimal();
        }

        public Task AddAsync(Animal animal)
            => _repository.AddAsync(animal.AsEntity());

        public Task UpdateAsync(Animal animal)
            => _repository.UpdateAsync(animal.AsEntity());

        public Task DeleteAsync(Animal animal)
            => _repository.DeleteAsync(animal.AsEntity());
    }
}

