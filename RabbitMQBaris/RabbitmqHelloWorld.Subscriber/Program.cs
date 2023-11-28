using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace RabbitmqHelloWorld.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            //NOTE: https://customer.cloudamqp.com/instance name > AMQP details > copy url to connect
            factory.Uri = new Uri("amqps://znxwrwvv:cTBKdtcXCNroP24le4FpPgl1PsDNhUC6@cow.rmq2.cloudamqp.com/znxwrwvv");
            using var connection = factory.CreateConnection();
            //create channel to communicate on
            var channel = connection.CreateModel();
            #region Simple Message receive queue Default Exchange
            //queue name, durable: false: in mermory & true: save physically, exclusive: is same channel or different, autodelete if subcribers down queue will be deleted?
            //NOTE: we can active it if our channel wasn't created by publisher. channel.QueueDeclare("hello-queue-baris", true, false, false);
            //NOTE: message size, message count to be sent at the same time, true: separate message count for all instance, false: sent message count each instance
            channel.BasicQos(0,1, false);
            var consumer = new EventingBasicConsumer(channel);
            //NOTE: if you want to remove queue manually do false, else do it true
            channel.BasicConsume("hello-queue-baris",false, consumer);
            consumer.Received += (object sender, BasicDeliverEventArgs e) => {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine("received message: "+ message);
                //NOTE: now we are deleting our message manually
                channel.BasicAck(e.DeliveryTag, false);
            };
            #endregion
            Console.ReadLine();
        }
    }
}
