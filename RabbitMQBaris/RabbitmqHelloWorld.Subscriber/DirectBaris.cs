using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitmqHelloWorld.Subscriber;

public class DirectBaris
{
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://uhshoatb:4tRfDsemduk6BCrsZaIvfQgOhLsMtf-t@fish.rmq.cloudamqp.com/uhshoatb");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            var queueName = "direct-queue-Critical";
            channel.BasicConsume(queueName,false, consumer);
            Console.WriteLine("Logs are listening...");
            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Thread.Sleep(1500);
                Console.WriteLine("Received Message:" + message);
               // File.AppendAllText("log-critical.txt", message+ "\n");
                channel.BasicAck(e.DeliveryTag, false);
            };
            Console.ReadLine();
        }
}
