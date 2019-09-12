using Microsoft.Extensions.DependencyInjection;
using ZooM.Application.Commands;
using ZooM.Application.Events;

namespace ZooM.Application
{
    public static class Extensions
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddCommandHandlers();
            services.AddEventHandlers();
        }
    }
}
