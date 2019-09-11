using System;
using System.Threading.Tasks;
using ZooM.Core.Entitites;

namespace ZooM.Core.Repositories
{
    public interface IAreaRepository
    {
        Task<Area> GetAsync(Guid id);
        Task AddAsync(Area animalAction);
        Task UpdateAsync(Area animalAction);
        Task DeleteAsync(Area animalAction);
    }
}
