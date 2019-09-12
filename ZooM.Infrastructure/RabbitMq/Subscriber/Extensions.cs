using ZooM.Application.Events.Employees;
using ZooM.Infrastructure.RabbitMq.CQRS;

namespace ZooM.Infrastructure.RabbitMq.Subscriber
{
    internal static class Extensions
    {
        public static void SubscribeEvents(this IMessageSubscriber subscriber)
        {
            subscriber.SubscribeEvent<EmployeeCreated>();
            subscriber.SubscribeEvent<EmployeeDeleted>();
            subscriber.SubscribeEvent<EmployeeUpdated>();
        }
    }
}
