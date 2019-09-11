using System;
using System.Threading.Tasks;
using ZooM.Core.Entitites;

namespace ZooM.Core.Repositories
{
    public interface IAreaRepository
    {
        Task<Area> GetAsync(Guid id);
        Task AddAsync(Area area);
        Task UpdateAsync(Area area);
        Task DeleteAsync(Area area);
    }
}
