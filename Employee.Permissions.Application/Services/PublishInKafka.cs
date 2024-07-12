using Confluent.Kafka;
using Employee.Permissions.Domain.Interfaces.QueueServices;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Employee.Permissions.Application.Services
{
    public class PublishInKafka : IPublishInQueue
    {

        private readonly IConfiguration _configuration;
        public PublishInKafka(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageToQueue<T>(T data)
        {
            await SendToQueue(data);
        }

        private async Task SendToQueue<T>(T data)
        {

            string host = _configuration.GetValue<string>("ServiceBus:Host");
            string topic = _configuration.GetValue<string>("ServiceBus:Topic");

            if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(topic)) throw new Exception("It is neccesary set the ServiceBus values in AppSettings");

            var message = new Message<string, string>()
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonSerializer.Serialize<T>(data)
            };

            var producerConfig = new ProducerConfig()
            {
                BootstrapServers = host,
                Acks = Acks.All
            };

            using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                await producer.ProduceAsync(topic, message);
            }
        }

    }
}
