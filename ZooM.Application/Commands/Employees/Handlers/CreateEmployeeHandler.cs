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
        private readonly IMessageBroker _broker;
        private readonly IEmployeeRepository _repository;

        public CreateEmployeeHandler(IEmployeeRepository repository, IMessageBroker broker)
        {
            _repository = repository;
            _broker = broker;
        }

        public async Task HandleAsync(CreateEmployee command)
        {
            var employee = await _repository.GetAsync(command.Id);

            if (employee != null) throw new EmployeeAlreadyExistException(command.Id);

            if (command.YearOfBirth > 2001 || command.YearOfBirth < 1930) throw new WrongDateException(command.YearOfBirth);

            var newEmployee = new Employee(command.Id, command.Avatar, command.Name, command.Position,
                command.YearOfBirth);

            await _repository.AddAsync(newEmployee);
            await _broker.PublishAsync(new EmployeeCreated(command.Id));
        }
    }
}