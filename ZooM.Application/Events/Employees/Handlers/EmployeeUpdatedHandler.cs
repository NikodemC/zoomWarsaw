using System;
using System.Threading.Tasks;

namespace ZooM.Application.Events.Employees.Handlers
{
    internal class EmployeeUpdatedHandler : IEventHandler<EmployeeUpdated>
    {
        public Task HandleAsync(EmployeeUpdated @event)
        {
            Console.WriteLine($"Employee with id: {@event.Id} has been updated");
            return Task.CompletedTask;
        }
    }
}