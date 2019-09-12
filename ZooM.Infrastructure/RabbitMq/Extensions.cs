using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using ZooM.Infrastructure.Options;

namespace ZooM.Infrastructure.RabbitMq
{
    internal static class Extensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services)
        {
            services.AddOption<RabbitMqOptions>("rabbitMq");
            services.AddSingleton(sp =>
            {
                var options = sp.GetService<RabbitMqOptions>();

                var factory = new ConnectionFactory
                {
                    HostName = options.HostName,
                    VirtualHost = options.VirtualHost,
                    UserName = options.Username,
                    Password = options.Password
                };

                return factory.CreateConnection();
            });

            services.AddSingleton<IMessageSubscriber, MessageSubscriber>();
            services.AddSingleton<IMessagePublisher, MessagePublisher>();

            return services;
        }
    }
}
