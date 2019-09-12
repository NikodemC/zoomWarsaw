using System;
using System.Threading.Tasks;

namespace ZooM.Application.Events.Employees.Handlers
{
    internal class EmployeeCreatedHandler : IEventHandler<EmployeeCreated>
    {
        public Task HandleAsync(EmployeeCreated @event)
        {
            Console.WriteLine($"Employee with id: {@event.Id} has been created");
            return Task.CompletedTask;
        }
    }
}
