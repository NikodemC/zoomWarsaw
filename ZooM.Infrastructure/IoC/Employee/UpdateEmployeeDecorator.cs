using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ZooM.Application.Commands;
using ZooM.Application.Commands.Employees;

namespace ZooM.Infrastructure.IoC.Employee
{
    internal class UpdateEmployeeDecorator : ICommandHandler<UpdateEmployee>
    {
        private readonly ICommandHandler<UpdateEmployee> _handler;
        private readonly ILogger<UpdateEmployeeDecorator> _logger;

        public UpdateEmployeeDecorator(ICommandHandler<UpdateEmployee> handler,
            ILogger<UpdateEmployeeDecorator> logger)
        {
            _handler = handler;
            _logger = logger;
        }

        public async Task HandleAsync(UpdateEmployee command)
        {
            _logger.LogInformation($"\n*** Started processing {nameof(UpdateEmployee)} ***");
            await _handler.HandleAsync(command);
            _logger.LogInformation($"*** Finished processing {nameof(UpdateEmployee)} ***\n");
        }
    }
}
