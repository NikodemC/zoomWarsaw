using System.Threading.Tasks;
using ZooM.Application.Exceptions.Employee;
using ZooM.Application.Services;
using ZooM.Core.Repositories;

namespace ZooM.Application.Commands.Employees.Handlers
{
    internal class DeleteEmployeeHandler : ICommandHandler<DeleteEmployee>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMessageBroker _broker;

        public DeleteEmployeeHandler(IEmployeeRepository repository, IMessageBroker broker)
        {
            _repository = repository;
            _broker = broker;
        }

        public async Task HandleAsync(DeleteEmployee command)
        {
            var employee = await _repository.GetAsync(command.Id);

            if (employee is null)
            {
                throw new EmployeeDoesntExistException(command.Id);
            }
            await _repository.DeleteAsync(employee);
        }
    }
}
