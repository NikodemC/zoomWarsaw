using System;
using System.Threading.Tasks;
using ZooM.Core.Entitites;

namespace ZooM.Core.Repositories
{
    public interface IAnimalActionRepository
    {
        Task<AnimalAction> GetAsync(Guid id);
        Task AddAsync(AnimalAction animalAction);
        Task UpdateAsync(AnimalAction animalAction);
        Task DeleteAsync(AnimalAction animalAction);
    }
}
