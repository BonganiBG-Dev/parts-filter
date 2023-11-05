using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceHunterFilter.Controllers;
using PriceHunterFilter.Services;
using PriceHunterFilterAPI.DataAccess.Model;
using PriceHunterFilterAPI.Filters;
using PriceHunterFilterAPI.Repository;
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
            using IHost host = Startup.CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;


            ProductController controller = new ProductController(services.GetService<IProductRepository>(), services.GetService<IRabbitMqService>());
            controller.Start();
        }
    }
}