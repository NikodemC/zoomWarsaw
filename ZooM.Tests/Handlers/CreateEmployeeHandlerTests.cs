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
    public class CreateEmployeeHandlerTests
    {
        Task Act(CreateEmployee command)
            => _handler.HandleAsync(command);

        [Fact]
        public async Task HandleAsync_Should_Throw_An_Exception_When_Employee_With_Given_Id_Already_Exists()
        {
            //ARRANGE
            var command = new CreateEmployee(Guid.NewGuid(), "No Avatar", "Testowy Testo", Position.Grabarz, 1980);
            var employee = new Employee(command.Id, "No Avatar", "Testowy Testo", Position.Grabarz, 1980);
            _repository.GetAsync(command.Id).Returns(employee);

            //ACT
            var exception = await Record.ExceptionAsync(async () => await Act(command));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeAssignableTo<EmployeeAlreadyExistException>();
        }

        [Fact]
        public async Task HandleAsync_Should_Throw_An_Exception_When_Employee_Year_Of_Birth_Is_Not_Within_The_Range()
        {
            //ARRANGE
            var command = new CreateEmployee(Guid.NewGuid(), "No Avatar", "Testowy Testo", Position.Grabarz, 2010);
     
            //ACT
            var exception = await Record.ExceptionAsync(async () => await Act(command));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeAssignableTo<WrongDateException>();
        }

        [Fact]
        public async Task HandleAsync_Should_Create_Employee_With_Given_Data_Using_Repository()
        {
            var command = new CreateEmployee(Guid.NewGuid(), "No Avatar", "Testowy Testo", Position.Grabarz, 1980);

            await Act(command);

            await _repository
                .Received(1)
                .AddAsync(Arg.Is<Employee>(e =>
                    e.Id == command.Id &&
                    e.Name == command.Name &&
                    e.Avatar == command.Avatar &&
                    e.Position == command.Position &&
                    e.YearOfBirth == command.YearOfBirth));
        }

        #region ARRANGE
        private readonly ICommandHandler<CreateEmployee> _handler;
        private readonly IEmployeeRepository _repository;
        private readonly IMessageBroker _broker;

        public CreateEmployeeHandlerTests()
        {
            _repository = Substitute.For<IEmployeeRepository>();
            _broker = Substitute.For<IMessageBroker>();
            _handler = new CreateEmployeeHandler(_repository, _broker);
        }
        #endregion
    }
}
