using System;

namespace ZooM.Application.Events.Employees
{
    public class EmployeeDeleted : IEvent
    {
        public Guid Id { get; }

        public EmployeeDeleted(Guid id)
        {
            Id = id;
        }
    }
}
