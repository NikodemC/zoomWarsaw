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
    public class UpdateEmployeeHandlerTests
    {
        Task Act(UpdateEmployee command)
            => _handler.HandleAsync(command);

        [Fact]
        public async Task HandleAsync_Should_Throw_An_Exception_When_Employee_With_Given_Id_Does_Not_Exist()
        {
            //ARRANGE
            var command = new UpdateEmployee(Guid.NewGuid(), Position.Opiekun, "Avatar");
            //ACT
            var exception = await Record.ExceptionAsync(async () => await Act(command));
            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeAssignableTo<EmployeeDoesntExistException>();
        }

        [Fact]
        public async Task HandleAsync_Should_Update_Deliverer_With_Given_Id_Using_Repository()
        {
            //ARRANGE
            var command = new UpdateEmployee(Guid.NewGuid(), Position.Opiekun, "Avatar");
            var employee = new Employee(command.Id, "No Avatar", "Testowy Testo", Position.Grabarz, 1980);
            _repository.GetAsync(command.Id).Returns(employee);

            //ACT
            await Act(command);

            //ASSERT
            await _repository.Received(1).UpdateAsync(employee);
        }

        #region ARRANGE
        private readonly ICommandHandler<UpdateEmployee> _handler;
        private readonly IEmployeeRepository _repository;
        private readonly IMessageBroker _broker;

        public UpdateEmployeeHandlerTests()
        {
            _repository = Substitute.For<IEmployeeRepository>();
            _broker = Substitute.For<IMessageBroker>();
            _handler = new UpdateEmployeeHandler(_repository, _broker);
        }
        #endregion

    }
}
