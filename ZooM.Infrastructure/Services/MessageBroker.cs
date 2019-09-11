using System.Threading.Tasks;
using ZooM.Application.Events;
using ZooM.Application.Services;

namespace ZooM.Infrastructure.Services
{
    internal sealed class MessageBroker : IMessageBroker
    {
        public async Task PublishAsync(params IEvent[] events)
        {
            await Task.Delay(1);
        }
    }
}
