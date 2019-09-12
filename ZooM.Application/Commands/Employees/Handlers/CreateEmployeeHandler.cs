using System.Threading.Tasks;
using ZooM.Application.Events.Employees;
using ZooM.Application.Exceptions.Employee;
using ZooM.Application.Services;
using ZooM.Core.Entitites;
using ZooM.Core.Repositories;

namespace ZooM.Application.Commands.Employees.Handlers
{

    internal class CreateEmployeeHandler : ICommandHandler<CreateEmployee>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMessageBroker _broker;

        public CreateEmployeeHandler(IEmployeeRepository repository, IMessageBroker broker)
        {
            _repository = repository;
            _broker = broker;
        }

        public async Task HandleAsync(CreateEmployee command)
        {
            var deliverer = await _repository.GetAsync(command.Id);

            if (deliverer != null)
            {
                throw new EmployeeAlreadyExistException(command.Id);
            }

            var newEmployee = new Employee(command.Id, command.Avatar, command.Name, command.Position, command.YearOfBirth);

            await _repository.AddAsync(newEmployee);
            await _broker.PublishAsync(new EmployeeCreated(command.Id));
        }
    }
}
