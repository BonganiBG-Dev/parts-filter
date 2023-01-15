using PriceHunterFilter.API.models;
using PriceHunterFilter.API.Services;
using PriceHunterFilter.Database.Interfaces;
using PriceHunterFilter.Services;
using PriceHunterFilter.Visuals;
using System.Diagnostics;

namespace PriceHunterFilter
{
    public class ProductFilter
    {
        private List<ScraperProduct> StagingProducts { get; set; }
        private ApiDataService _dataService;
        
        public ProductFilter(List<ScraperProduct> products)
        {
            StagingProducts = products;            
        }

        public ProductFilter(List<ScraperProduct> stagingProducts, IDataAccess<Product> dataAccess) : this(stagingProducts)
        {
            _dataService = new ApiDataService(dataAccess);
        }

        public void Start()
        {
            ProgressBar progressBar = new ProgressBar();
            for (int i = 0; i < StagingProducts.Count; i++)
            {
                Product product = ConvertToDatabaseProduct(StagingProducts[i]);

                if (_dataService.ProductExists(product._id))
                    _dataService.UpdatePrice(product._id, product);
                else
                    _dataService.AddProduct(product);

                 progressBar.Show(i, StagingProducts.Count());
            }
        }

        public Product ConvertToDatabaseProduct(ScraperProduct product)
        {
            Product apiProduct = CreateNewProduct(product);

            apiProduct.Price_history.Add(GetInitialPrice(apiProduct.Price));

            return apiProduct;
        }

        private Product CreateNewProduct(ScraperProduct product)
        {
            GenerateProductID idGenerator = new GenerateProductID();
            PriceFilter priceFilter = new PriceFilter();
            CategoryFilterService categoryFilter = new CategoryFilterService(Config.CATEGORIES);
            SiteFilterService siteFilter = new SiteFilterService(Config.WEBSITES);

            return new Product
            {
                _id = idGenerator.GetID(product.Site + product.Name),
                Category_id = categoryFilter.GetCategoryId(product.Category),
                Name = product.Name,
                Img_url = product.Image,
                Page_link = product.Link,
                Last_updated = DateTime.Now,
                Series_id = "",
                Site_id = siteFilter.GetSiteId(product.Site),
                __v = 0,
                Price = priceFilter.FilterPrice(product.Price),
                Price_history = new()
            };
        }

        private PriceHistory GetInitialPrice(double price)
        {
            return new PriceHistory
            {
                Price = price,
                Updated_on = DateTime.Now
            };
        }
        
    }
}