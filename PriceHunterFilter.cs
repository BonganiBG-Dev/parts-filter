using PriceHunterFilter.API.models;
using PriceHunterFilter.API.Repositories;
using PriceHunterFilter.Database;
using PriceHunterFilter.Database.Interfaces;
using PriceHunterFilter.Scraper.Services;
using System.Diagnostics;

namespace PriceHunterFilter
{
    public class PriceHunterMain
    {
        private readonly ScrapedDataService _dataService;

        public PriceHunterMain()
        {
            _dataService = new ScrapedDataService(SetupDataAccess());
            LoadDatabaseValues();
        }

        public PriceHunterMain(string mongoClient, string database, string apiCollection, string scraperCollection)
        {
            Config.DATABASE_NAME = mongoClient;
            Config.API_COLLECTION = apiCollection;
            Config.SCRAPER_COLLECTION = scraperCollection;
            Config.DATABASE_NAME = database;
            _dataService = new ScrapedDataService(SetupDataAccess());
            LoadDatabaseValues();
        }

        private void LoadDatabaseValues()
        {
            SiteRepository siteRepo = new SiteRepository(SetupSiteDataAccess());
            CategoryRepository catRepo = new CategoryRepository(SetupCategoryDataAccess());

            Config.CATEGORIES = catRepo.GetCategories();
            Config.WEBSITES = siteRepo.GetSites();
        }

        private IDataAccess<Site> SetupSiteDataAccess()
        {
            IMongoConnection connection = new MongoConnection(Config.MONGO_CLIENT, Config.DATABASE_NAME);
            return new DataAccess<Site>(connection, Config.SITE_COLLECTION);
        }

        private IDataAccess<Category> SetupCategoryDataAccess()
        {
            IMongoConnection connection = new MongoConnection(Config.MONGO_CLIENT, Config.DATABASE_NAME);
            return new DataAccess<Category>(connection, Config.CATEGORY_COLLECTION);
        }

        public void Start()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (_dataService.HasNextCategory())
            {
                List<ScraperProduct> products = _dataService.GetNextCategory();
                ProductFilter filter = new ProductFilter(products, SetupApiDataAccess());

                filter.Start();
            }
            timer.Stop();
            RunLogs.TotalRunTime = timer.ElapsedMilliseconds;

            //DisplayLogs();
        }

        public Dictionary<string,string> GetLogs()
        {
            var output = new Dictionary<string, string>();
            output.Add("New Products", RunLogs.NewItems.ToString());
            output.Add("Updated", RunLogs.UpdatedItems.ToString());
            output.Add("Completed In", RunLogs.TotalRunTime.ToString());

            return output;

        }

        private void DisplayLogs()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Product Filtration Logs");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine($"New Products: {RunLogs.NewItems}");
            Console.WriteLine($"Updated Products: {RunLogs.UpdatedItems}");
            Console.WriteLine($"Completed in: {RunLogs.TotalRunTime}ms");
            Console.WriteLine("------------------------------------------------------------------------------");
        }
        
        private IDataAccess<ScraperProduct> SetupDataAccess()
        {
            IMongoConnection connection = new MongoConnection(Config.MONGO_CLIENT,Config.DATABASE_NAME);
            return new DataAccess<ScraperProduct>(connection, Config.SCRAPER_COLLECTION);
        }

        private IDataAccess<Product> SetupApiDataAccess()
        {
            IMongoConnection connection = new MongoConnection(Config.MONGO_CLIENT, Config.DATABASE_NAME);
            return new DataAccess<Product>(connection, Config.API_COLLECTION);
        }
    }
}
