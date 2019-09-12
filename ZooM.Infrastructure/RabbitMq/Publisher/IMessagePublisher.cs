using System.Threading.Tasks;

namespace ZooM.Infrastructure.RabbitMq.Publisher
{
    public interface IMessagePublisher
    {
        Task PublishAsync<TMessage>(TMessage message) where TMessage : class;
    }
}
