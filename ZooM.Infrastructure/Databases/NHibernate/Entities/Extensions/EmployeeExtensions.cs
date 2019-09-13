using System.Collections.Generic;
using System.Linq;
using ZooM.Application.DTO;
using ZooM.Core.Entitites;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions
{
    internal static class EmployeeExtensions
    {
        public static EmployeeEntity AsEntity(this Employee employee)
        {
            return new EmployeeEntity
            {
                Id = employee.Id,
                Avatar = employee.Avatar,
                Name = employee.Name,
                Position = employee.Position,
                YearOfBirth = employee.YearOfBirth
            };
        }

        public static Employee AsEmployee(this EmployeeEntity entity)
        {
            return new Employee(entity.Id, entity.Avatar, entity.Name, entity.Position, entity.YearOfBirth);
        }

        public static EmployeeDto AsDto(this EmployeeEntity entity)
        {
            return new EmployeeDto
            {
                Id = entity.Id,
                Avatar = entity.Avatar,
                Name = entity.Name,
                Position = entity.Position,
                YearOfBirth = entity.YearOfBirth
            };
        }

        public static IEnumerable<EmployeeDto> AsDtos(this IEnumerable<EmployeeEntity> employees)
        {
            return employees.Select(a => a.AsDto());
        }
    }
}