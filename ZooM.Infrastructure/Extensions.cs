using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ZooM.Application.Services;
using ZooM.Infrastructure.Databases;
using ZooM.Infrastructure.Dispatchers;
using ZooM.Infrastructure.IoC;
using ZooM.Infrastructure.Queries.Handlers;
using ZooM.Infrastructure.Repositories;
using ZooM.Infrastructure.Services;

namespace ZooM.Infrastructure
{
    public static class Extensions
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddDispatchers();
            services.AddQueryHandlers();
            services.AddRepositories();
            services.AddDatabase();
            services.AddDecorators();
            services.AddTransient<IMessageBroker, MessageBroker>();
        }
        public static void UseInfrastructure(this IApplicationBuilder app)
        {

        }
}

}
