﻿using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitmqHelloWorld.Shared;

namespace RabbitmqHelloWorld.Subscriber;

public class HeaderComplexTypeBaris
{
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://uhshoatb:4tRfDsemduk6BCrsZaIvfQgOhLsMtf-t@fish.rmq.cloudamqp.com/uhshoatb");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            var queueName = channel.QueueDeclare().QueueName;
            Dictionary<string, object> headers = new Dictionary<string, object>();
            headers.Add("format", "pdf");
            headers.Add("shape", "a4");
            headers.Add("x-match", "any");
            channel.QueueBind(queueName, "header-exchange",String.Empty,headers);
            channel.BasicConsume(queueName,false, consumer);
            Console.WriteLine("Logs listening...");
            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Product product = JsonSerializer.Deserialize<Product>(message);
                Thread.Sleep(1029);//to see in the console smoothly how the messages are sent
                Console.WriteLine($"Message Received: { product.Id}-{ product.Name}-{product.Price}-{product.Stock}");
                channel.BasicAck(e.DeliveryTag, false);
            };
            Console.ReadLine();
        }
}
