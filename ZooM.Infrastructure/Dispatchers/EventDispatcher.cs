using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ZooM.Application.Events;
using ZooM.Application.Events.Dispatchers;

namespace ZooM.Infrastructure.Dispatchers
{
    internal class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task DispatchAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var handler = _serviceProvider.GetService<IEventHandler<TEvent>>();
            return handler.HandleAsync(@event);
        }
    }
}
