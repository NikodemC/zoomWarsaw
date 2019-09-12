using System;
using System.Threading.Tasks;

namespace ZooM.Infrastructure.RabbitMq.Subscriber
{
    internal interface IMessageSubscriber
    {
        void Subscribe<TMessage>(Func<IServiceProvider, TMessage, Task> onReceived) where TMessage : class;
    }
}
