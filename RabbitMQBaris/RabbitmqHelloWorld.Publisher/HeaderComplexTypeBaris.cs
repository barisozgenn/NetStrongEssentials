﻿using RabbitMQ.Client;
using RabbitmqHelloWorld.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
namespace RabbitmqHelloWorld.Publisher;

public class HeaderComplexTypeBaris
{
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://znxwrwvv:cTBKdtcXCNroP24le4FpPgl1PsDNhUC6@cow.rmq2.cloudamqp.com/znxwrwvv");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);
            Dictionary<string, object> headers = new Dictionary<string, object>();
            headers.Add("format", "pdf");
            headers.Add("shape2", "a4");

            var properties = channel.CreateBasicProperties();
            properties.Headers = headers;
            properties.Persistent = true; //to avoid message removing

            var product = new Product { Id = 7, Name = "Pencil", Price = 14, Stock = 29 };
            var productJsonString = JsonSerializer.Serialize(product);
            channel.BasicPublish("header-exchange", string.Empty, properties, Encoding.UTF8.GetBytes(productJsonString));
            Console.WriteLine("Message is sent");
            Console.ReadLine();
        }
}
