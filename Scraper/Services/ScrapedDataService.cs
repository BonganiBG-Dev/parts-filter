using MongoDB.Driver;
using PriceHunterFilter.Database;
using PriceHunterFilter.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.Scraper.Services
{
    public class ScrapedDataService
    {
        private readonly IDataAccess<ScraperProduct> _dataAccess;
        private List<ScraperProduct> products = new List<ScraperProduct>();
        private Queue<string> categories;

        public ScrapedDataService(IDataAccess<ScraperProduct> dataAccess)
        {
            _dataAccess = dataAccess;
            CreateQueue();
        }

        private void CreateQueue()
        {
            categories = new Queue<string>();
            categories.Enqueue("Memory");
            categories.Enqueue("Graphics Card");
            categories.Enqueue("Processors");
            categories.Enqueue("Motherboard");
            categories.Enqueue("Power Supply");
            categories.Enqueue("Solid State Drive");
            categories.Enqueue("Hard Drive");
            categories.Enqueue("Case");
            categories.Enqueue("Case Fans");
            categories.Enqueue("CPU Cooler");
            categories.Enqueue("Monitor");
        }

        public List<ScraperProduct> GetNextCategory()
        {
            if (HasNextCategory())
                return GetProducts(categories.Dequeue());

            return new();
        }

        public bool HasNextCategory()
        {
            return categories.Count > 0 ? true : false;
        }

        private List<ScraperProduct> GetProducts(string category)
        {
            var filter = Builders<ScraperProduct>.Filter.Eq("Category", category);
            return _dataAccess.Get(filter);
        }
    }
}
