using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace RabbitmqHelloWorld.Publisher
{
    class HeaderBaris
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://znxwrwvv:cTBKdtcXCNroP24le4FpPgl1PsDNhUC6@cow.rmq2.cloudamqp.com/znxwrwvv");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare("logs-fanout", durable: true, type: ExchangeType.Fanout);
            Enumerable.Range(1, 50).ToList().ForEach(x =>
            {
                string message = $"log {x}";
                var messageBody = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("logs-fanout","", null, messageBody);
                Console.WriteLine($"Message is sent : {message}");
            });
            Console.ReadLine();
        }
    }
}


