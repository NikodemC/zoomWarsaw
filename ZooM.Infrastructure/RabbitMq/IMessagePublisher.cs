using System.Threading.Tasks;

namespace ZooM.Infrastructure.RabbitMq
{
    public interface IMessagePublisher
    {
        Task PublishAsync<TMessage>(TMessage message) where TMessage : class;
    }
}
