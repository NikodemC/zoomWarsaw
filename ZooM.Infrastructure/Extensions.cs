using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ZooM.Application.Services;
using ZooM.Infrastructure.Databases;
using ZooM.Infrastructure.Dispatchers;
using ZooM.Infrastructure.IoC;
using ZooM.Infrastructure.Queries.Handlers;
using ZooM.Infrastructure.RabbitMq;
using ZooM.Infrastructure.RabbitMq.Subscriber;
using ZooM.Infrastructure.Repositories;
using ZooM.Infrastructure.Services;
using ZooM.Infrastructure.Swagger;

namespace ZooM.Infrastructure
{
    public static class Extensions
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddDispatchers();
            services.AddQueryHandlers();
            services.AddDecorators();
            services.AddRepositories();
            services.AddDatabase();
            services.AddSwagger();
            services.AddTransient<IMessageBroker, MessageBroker>();
            services.AddRabbitMq();
        }
        public static void UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseSwaggerExtension();

            var subscriber = app.ApplicationServices.GetService<IMessageSubscriber>();
            subscriber.SubscribeEvents();
        }
}

}
