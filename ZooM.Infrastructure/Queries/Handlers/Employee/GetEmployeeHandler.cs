using System.Threading.Tasks;
using ZooM.Application.DTO;
using ZooM.Application.Queries;
using ZooM.Application.Queries.Employees;
using ZooM.Infrastructure.Databases;
using ZooM.Infrastructure.Databases.NHibernate.Entities;
using ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions;

namespace ZooM.Infrastructure.Queries.Handlers.Employee
{
    internal class GetEmployeeHandler : IQueryHandler<GetEmployee, EmployeeDto>
    {
        private readonly IRepository<EmployeeEntity> _repository;

        public GetEmployeeHandler(IRepository<EmployeeEntity> repository)
            => _repository = repository;

        public async Task<EmployeeDto> HandleAsync(GetEmployee query)
        {
            var employee = await _repository.GetAsync(query.Id);
            return employee?.AsDto();
        }
    }
}
