using System;

namespace ZooM.Application.Commands.Employees
{
    public class DeleteEmployee : ICommand
    {
        public Guid Id { get; }

        public DeleteEmployee(Guid id)
        {
            Id = id;
        }
    }
}
