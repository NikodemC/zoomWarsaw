using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooM.Application.DTO;
using ZooM.Application.Queries;
using ZooM.Application.Queries.Employees;
using ZooM.Infrastructure.Databases;
using ZooM.Infrastructure.Databases.NHibernate.Entities;
using ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions;

namespace ZooM.Infrastructure.Queries.Handlers.Employee
{
    internal class SearchEmployeesHandler : IQueryHandler<SearchEmployees, IEnumerable<EmployeeDto>>
    {
        private readonly IRepository<EmployeeEntity> _repository;

        public SearchEmployeesHandler(IRepository<EmployeeEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDto>> HandleAsync(SearchEmployees query)
        {
            var entities = await _repository.SearchAsync(e => !query.Position.HasValue || e.Position == query.Position);

            if (query.YearOfBirth != null)
                entities = entities.Where(e => e.YearOfBirth <= query.YearOfBirth);

            entities = entities.Where(d =>
                string.IsNullOrEmpty(query.Name) || d.Name.ToLower().StartsWith(query.Name.ToLower()));

            return entities.AsDtos();
        }
    }
}