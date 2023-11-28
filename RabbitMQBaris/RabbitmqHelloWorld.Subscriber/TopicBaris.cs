using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitmqHelloWorld.Subscriber;

public class TopicBaris
{
static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://uhshoatb:4tRfDsemduk6BCrsZaIvfQgOhLsMtf-t@fish.rmq.cloudamqp.com/uhshoatb");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var randomQueueName = channel.QueueDeclare().QueueName;
            //when app is stop running our queue will be deleted by QueueBind
            channel.QueueBind(randomQueueName, "logs-fanout", "", null);
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(randomQueueName,false, consumer);
            Console.WriteLine("Logs are listening...");
            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Thread.Sleep(1500);
                Console.WriteLine("Received:" + message);
                channel.BasicAck(e.DeliveryTag, false);
            };
            Console.ReadLine();
        }
}
