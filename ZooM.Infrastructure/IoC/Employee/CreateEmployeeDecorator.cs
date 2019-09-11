using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ZooM.Application.Commands;
using ZooM.Application.Commands.Employees;

namespace ZooM.Infrastructure.IoC.Employee
{
    internal class CreateEmployeeDecorator : ICommandHandler<CreateEmployee>
    {
        private readonly ICommandHandler<CreateEmployee> _handler;
        private readonly ILogger<CreateEmployeeDecorator> _logger;

        public CreateEmployeeDecorator(ICommandHandler<CreateEmployee> handler,
            ILogger<CreateEmployeeDecorator> logger)
        {
            _handler = handler;
            _logger = logger;
        }

        public async Task HandleAsync(CreateEmployee command)
        {
            _logger.LogInformation($"\n*** Started processing {nameof(CreateEmployee)} ***");
            await _handler.HandleAsync(command);
            _logger.LogInformation($"*** Finished processing {nameof(CreateEmployee)} ***\n");
        }
    }
}
