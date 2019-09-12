using System.Collections.Generic;
using ZooM.Application.DTO;
using ZooM.Core.Enums;

namespace ZooM.Application.Queries.Employees
{
    public class SearchEmployees : IQuery<IEnumerable<EmployeeDto>>
    {
        public string Name { get; set; }
        public Position? Position { get; set; }
        public int? YearOfBirth { get; set; }
    }
}
