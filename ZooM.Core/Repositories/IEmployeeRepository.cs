using System;
using System.Threading.Tasks;
using ZooM.Core.Entitites;

namespace ZooM.Core.Repositories
{

    public interface IEmployeeRepository
    {
        Task<Employee> GetAsync(Guid id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
    }
}
