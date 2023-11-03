using PriceHunterFilter.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace PriceHunterFilter
{    
    internal class Program
    {
        static void Main(string[] args)
        {
            RabbitMqService rabbitService = new RabbitMqService();

            rabbitService.Consume((data) =>
            {
                Console.WriteLine(data);
            });
        }

        private static bool TryDeserialize<T>(string jsonObject, out T dataObj)
        {
            bool assigned = false;

            try
            {
                dataObj = JsonSerializer.Deserialize<T>(jsonObject);
                assigned = true;
            }
            catch (Exception)
            {
                dataObj = default(T);
                // Log the error
            }

            return assigned;
        }
    }
}