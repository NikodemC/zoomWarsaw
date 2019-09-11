using Microsoft.Extensions.DependencyInjection;
using ZooM.Application.Commands.Dispatchers;
using ZooM.Application.Events.Dispatchers;
using ZooM.Application.Queries.Dispatchers;

namespace ZooM.Infrastructure.Dispatchers
{
    internal static class Extensions
    {
        public static void AddDispatchers(this IServiceCollection services)
        {
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IEventDispatcher, EventDispatcher>();
        }
    }
}
