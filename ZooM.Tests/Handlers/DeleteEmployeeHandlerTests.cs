using NSubstitute;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using ZooM.Application.Commands;
using ZooM.Application.Commands.Employees;
using ZooM.Application.Commands.Employees.Handlers;
using ZooM.Application.Exceptions.Employee;
using ZooM.Application.Services;
using ZooM.Core.Entitites;
using ZooM.Core.Enums;
using ZooM.Core.Repositories;

namespace ZooM.Tests.Handlers
{
    public class DeleteEmployeeHandlerTests
    {
        Task Act(DeleteEmployee command)
            => _handler.HandleAsync(command);

        [Fact]
        public async Task HandleAsync_Should_Throw_An_Exception_When_Employee_With_Given_Id_Does_Not_Exist()
        {
            //ARRANGE
            var command = new DeleteEmployee(Guid.NewGuid());

            //ACT
            var exception = await Record.ExceptionAsync(async () => await Act(command));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeAssignableTo<EmployeeDoesntExistException>();
        }

        [Fact]
        public async Task HandleAsync_Should_Delete_Employee_With_Given_Id_Using_Repository()
        {
            var command = new DeleteEmployee(Guid.NewGuid());
            var employee = new Employee(command.Id, "No Avatar", "Testowy Testo", Position.Grabarz, 1980);

            _repository.GetAsync(command.Id).Returns(employee);

            await Act(command);
            await _repository.Received(1).DeleteAsync(employee);
        }

        #region ARRANGE
        private readonly ICommandHandler<DeleteEmployee> _handler;
        private readonly IEmployeeRepository _repository;
        private readonly IMessageBroker _broker;

        public DeleteEmployeeHandlerTests()
        {
            _repository = Substitute.For<IEmployeeRepository>();
            _broker = Substitute.For<IMessageBroker>();
            _handler = new DeleteEmployeeHandler(_repository, _broker);
        }
        #endregion
    }
}
