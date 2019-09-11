using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ZooM.Application.Commands;
using ZooM.Application.Commands.Employees;

namespace ZooM.Infrastructure.IoC.Employee
{

    internal class DeleteEmployeeDecorator : ICommandHandler<DeleteEmployee>
    {
        private readonly ICommandHandler<DeleteEmployee> _handler;
        private readonly ILogger<DeleteEmployeeDecorator> _logger;

        public DeleteEmployeeDecorator(ICommandHandler<DeleteEmployee> handler,
            ILogger<DeleteEmployeeDecorator> logger)
        {
            _handler = handler;
            _logger = logger;
        }

        public async Task HandleAsync(DeleteEmployee command)
        {
            _logger.LogInformation($"\n*** Started processing {nameof(DeleteEmployee)} ***");
            await _handler.HandleAsync(command);
            _logger.LogInformation($"*** Finished processing {nameof(DeleteEmployee)} ***\n");
        }
    }
}
