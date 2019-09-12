using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;
using ZooM.Infrastructure.Options;

namespace ZooM.Infrastructure.RabbitMq
{
    internal class MessagePublisher : IMessagePublisher
    {
        private readonly IConnection _connection;
        private readonly RabbitMqOptions _options;

        public MessagePublisher(IConnection connection, RabbitMqOptions options)
        {
            _connection = connection;
            _options = options;
        }

        public Task PublishAsync<TMessage>(TMessage message) where TMessage : class
        {
            using (var channel = _connection.CreateModel())
            {
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: _options.Exchange,
                    routingKey: message.GetType().Name,
                    basicProperties: null,
                    body: body);
            }

            return Task.CompletedTask;
        }
    }
}
