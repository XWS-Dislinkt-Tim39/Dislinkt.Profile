using Dislinkt.Profile.Core.MessageProducers;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Dislinkt.Profile.RabbitMQ.MessageProducers
{
    public class MessageProducer : IMessageProducer
    {
        public void SendRegistrationMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("users-registration");

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "users-registration", body: body);
        }
    }
}
