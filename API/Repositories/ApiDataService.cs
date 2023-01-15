using PriceHunterFilter.API.models;
using PriceHunterFilter.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.API.Services
{
    public class ApiDataService
    {
        private readonly IDataAccess<Product> _dataAccess;

        public ApiDataService(IDataAccess<Product> dataAccess)
        {
            _dataAccess = dataAccess;            
        }

        public bool ProductExists(string id)
        {
            return _dataAccess.Exists(id);
        }

        public void AddProduct(Product product)
        {
            _dataAccess.Create(product, product._id);
            RunLogs.NewItems++;
            Console.WriteLine("New Product");
        }

        public void UpdatePrice(string id, Product product)
        {
            if (!HasPriceChanged(id, product.Price))
                return;
            
            AddNewPriceToHistory(ref product, product.Price);
            _dataAccess.Update(product, id);
            RunLogs.UpdatedItems++;
            Console.WriteLine("Updated");
        }    
        
        private bool HasPriceChanged(string id, double newPrice)
        {
            double currentPrice = _dataAccess.Get(id).Price;

            return currentPrice != newPrice ? true : false;
        }

        private void AddNewPriceToHistory(ref Product product, double price)
        {
            product.Price_history.Add(new PriceHistory
            {
                Price = price,
                Updated_on = DateTime.Now
            });
        }
    }
}
