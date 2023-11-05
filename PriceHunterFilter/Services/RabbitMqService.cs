using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.Services
{
    delegate void HandleProduct(string data);
    internal class RabbitMqService : IRabbitMqService
    {
        public RabbitMqService()
        {
            Console.WriteLine("We are in the Rabbit Service");
        }

        public void Consume(HandleProduct handleProductDel)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            factory.ClientProvidedName = "PC Price Hunter Filter";

            IConnection cnn = factory.CreateConnection();

            IModel channel = cnn.CreateModel();

            string exchangeName = "PcPriceHunterExchange";
            string routingKey = "pc-price-hunter-key";
            string queueName = "PcPriceHunterQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, true, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                string product = Encoding.UTF8.GetString(body);

                handleProductDel(product);
                channel.BasicAck(args.DeliveryTag, false);
            };

            string consumerTag = channel.BasicConsume(queueName, false, consumer);
            Console.Write("Press CTRL + C to stop");
            Console.ReadLine();

            channel.BasicCancel(consumerTag);
            channel.Close();
            cnn.Close();
        }


    }
}
