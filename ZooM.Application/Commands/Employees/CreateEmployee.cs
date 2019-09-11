using System;
using ZooM.Core.Enums;

namespace ZooM.Application.Commands.Employees
{
    public class CreateEmployee : ICommand
    {
        public Guid Id { get; }
        public string Avatar { get; }
        public string Name { get; }
        public Position Position { get; }
        public int YearOfBirth { get; }

        public CreateEmployee(Guid id, string avatar, string name, Position position, int yearOfBirth)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Avatar = avatar;
            Name = name;
            Position = position;
            YearOfBirth = yearOfBirth;
        }
    }
}
