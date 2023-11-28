using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace RabbitmqHelloWorld.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            //NOTE: https://customer.cloudamqp.com/instance name > AMQP details > copy url to connect
            factory.Uri = new Uri("amqps://znxwrwvv:cTBKdtcXCNroP24le4FpPgl1PsDNhUC6@cow.rmq2.cloudamqp.com/znxwrwvv");

            using var connection = factory.CreateConnection();
            //NOTE: create channel to communicate on
            var channel = connection.CreateModel();

            #region Simple Message sent queue Default Exchange Type
            //NOTE: queue name, durable: false: in mermory & true: save physically, exclusive: is same channel or different, autodelete if subcribers down queue will be deleted?
            channel.QueueDeclare("hello-queue-baris", true, false, false);
            Enumerable.Range(1,50).ToList().ForEach(it => {
            string message = $"baris mesaj {it}";
            var messageBody = Encoding.UTF8. GetBytes(message);
            channel.BasicPublish(string.Empty, "hello-queue-baris", null, messageBody);
            Console.WriteLine($"Message is sent: {message}");
            });
            #endregion

            Console.ReadLine();
        }
    }
}
