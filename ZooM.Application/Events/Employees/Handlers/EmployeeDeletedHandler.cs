using System;
using System.Threading.Tasks;

namespace ZooM.Application.Events.Employees.Handlers
{
    internal class EmployeeDeletedHandler : IEventHandler<EmployeeDeleted>
    {
        public Task HandleAsync(EmployeeDeleted @event)
        {
            Console.WriteLine($"Employee with id: {@event.Id} has been deleted");
            return Task.CompletedTask;
        }
    }
}
