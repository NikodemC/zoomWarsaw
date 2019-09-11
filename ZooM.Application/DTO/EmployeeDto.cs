using System;
using ZooM.Core.Enums;

namespace ZooM.Application.DTO
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public int YearOfBirth { get; set; }
    }
}
