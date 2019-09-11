using System;
using System.Threading.Tasks;
using ZooM.Core.Entitites;
using ZooM.Core.Repositories;
using ZooM.Infrastructure.Databases;
using ZooM.Infrastructure.Databases.NHibernate.Entities;
using ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions;

namespace ZooM.Infrastructure.Repositories
{
    internal class EmployeeDatabaseRepository : IEmployeeRepository
    {
        private readonly IRepository<EmployeeEntity> _repository;

        public EmployeeDatabaseRepository(IRepository<EmployeeEntity> repository)
            => _repository = repository;

        public async Task<Employee> GetAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            return entity?.AsEmployee();
        }

        public Task AddAsync(Employee employee)
            => _repository.AddAsync(employee.AsEntity());

        public Task UpdateAsync(Employee employee)
            => _repository.UpdateAsync(employee.AsEntity());

        public Task DeleteAsync(Employee employee)
            => _repository.DeleteAsync(employee.AsEntity());
    }
}
