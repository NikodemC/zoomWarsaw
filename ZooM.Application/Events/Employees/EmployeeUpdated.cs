using System;

namespace ZooM.Application.Events.Employees
{

    public class EmployeeUpdated : IEvent
    {
        public Guid Id { get; }

        public EmployeeUpdated(Guid id)
        {
            Id = id;
        }
    }
}
