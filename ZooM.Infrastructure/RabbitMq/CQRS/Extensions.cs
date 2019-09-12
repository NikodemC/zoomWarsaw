using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using ZooM.Application.Events;
using ZooM.Application.Events.Dispatchers;

namespace ZooM.Infrastructure.RabbitMq.CQRS
{
    internal static class Extensions
    {

        public static void SubscribeEvent<TEvent>(this IMessageSubscriber subscriber)
            where TEvent : class, IEvent
            => subscriber.Subscribe<TEvent>(async (sp, @event) =>
            {
                var dispatcher = sp.GetService<IEventDispatcher>();
                await dispatcher.DispatchAsync(@event);
            });

        public static Task PublishEventAsync<TEvent>(this IMessagePublisher publisher,
            TEvent @event)
            where TEvent : class, IEvent
            => publisher.PublishAsync(@event);
    }
}
