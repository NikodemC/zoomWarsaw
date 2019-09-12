using System.Linq;
using System.Threading.Tasks;
using ZooM.Application.Events;
using ZooM.Application.Services;
using ZooM.Infrastructure.RabbitMq;
using ZooM.Infrastructure.RabbitMq.CQRS;

namespace ZooM.Infrastructure.Services
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IMessagePublisher _publisher;

        public MessageBroker(IMessagePublisher publisher)
            => _publisher = publisher;

        public async Task PublishAsync(params IEvent[] events)
        {
            var tasks = events.Select(e => _publisher.PublishEventAsync(e));
            await Task.WhenAll(tasks);
        }
    }
}
