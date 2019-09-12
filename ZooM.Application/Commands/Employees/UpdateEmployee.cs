using System;
using ZooM.Core.Enums;

namespace ZooM.Application.Commands.Employees
{
    public class UpdateEmployee : ICommand
    {
        public Guid Id { get; }
        public Position? Position { get; }
        public string Avatar { get; }

        public UpdateEmployee(Guid id, Position? position, string avatar)
        {
            Id = id;
            Position = position;
            Avatar = avatar;
        }
    }
}
