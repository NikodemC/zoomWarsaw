using System;

namespace ZooM.Application.Events.Employees
{
    public class EmployeeCreated : IEvent
    {
        public Guid Id { get; }

        public EmployeeCreated(Guid id)
        {
            Id = id;
        }
    }
}
