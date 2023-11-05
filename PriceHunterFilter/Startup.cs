using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceHunterFilter.Services;
using PriceHunterFilterAPI.DataAccess;
using PriceHunterFilterAPI.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter
{
    internal class Startup
    {
        public static IHostBuilder CreateHostBuilder(string[] strings)
        {
            return Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
            {                
                services.AddSingleton<IDataAccess, SqlAccess>();
                services.AddSingleton<IProductRepository, ProductRepository>();
                services.AddSingleton<IRabbitMqService, RabbitMqService>();
            });
        }
    }
}
