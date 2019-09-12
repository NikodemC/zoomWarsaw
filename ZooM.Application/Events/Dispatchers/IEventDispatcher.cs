using System.Threading.Tasks;

namespace ZooM.Application.Events.Dispatchers
{
    public interface IEventDispatcher
    {
        Task DispatchAsync<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }
}
