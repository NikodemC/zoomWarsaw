using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ZooM.Application.Commands;
using ZooM.Application.Commands.Dispatchers;

namespace ZooM.Infrastructure.Dispatchers
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
            return handler.HandleAsync(command);
        }
    }
}
