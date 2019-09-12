using System.Threading.Tasks;
using ZooM.Application.Events;

namespace ZooM.Application.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
    }
}
