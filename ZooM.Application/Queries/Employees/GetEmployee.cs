using System;
using ZooM.Application.DTO;

namespace ZooM.Application.Queries.Employees
{
    public class GetEmployee : IQuery<EmployeeDto>
    {
        public Guid Id { get; set; }
    }
}
