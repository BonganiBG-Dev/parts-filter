using PriceHunterFilter.Services;
using PriceHunterFilterAPI.DataAccess.Model;
using PriceHunterFilterAPI.DTOs;
using PriceHunterFilterAPI.Filters;
using PriceHunterFilterAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PriceHunterFilter.Controllers
{
    internal class ProductController
    {
        private readonly IProductRepository _productRepository;
        private readonly IRabbitMqService _rabbitService;
        private readonly ProductFilter _productFilter;
        
        public ProductController(IProductRepository productRepository, IRabbitMqService rabbitService)
        {
            _productRepository = productRepository;
            _rabbitService = rabbitService;
            _productFilter = new ProductFilter();
        }

        public void Start()
        {
            Console.WriteLine("We are in the Product Controller");
            _rabbitService.Consume((productString) =>
            {
                
                var product = JsonSerializer.Deserialize<ProductRaw>(productString);               
                var output = _productFilter.FilterProduct(product);

                _productRepository.Upsert(output);
                _productRepository.UpdatePrice(output.Id, output.Price);                
            });
        }
    }
}
