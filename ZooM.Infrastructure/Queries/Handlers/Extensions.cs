using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using ZooM.Application.DTO;
using ZooM.Application.Queries;
using ZooM.Application.Queries.Employees;
using ZooM.Infrastructure.Queries.Handlers.Employee;

namespace ZooM.Infrastructure.Queries.Handlers
{
    internal static class Extensions
    {
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<GetEmployee, EmployeeDto>, GetEmployeeHandler>();
            services.AddTransient<IQueryHandler<SearchEmployees, IEnumerable<EmployeeDto>>, SearchEmployeesHandler>();
        }
    }
}
