using PriceHunterFilterAPI.DataAccess;
using PriceHunterFilterAPI.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilterAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            Console.WriteLine("We are in the Product Repo");
            _dataAccess = dataAccess;
        }

        /// <summary>
        /// Updates existing products or creates a new product
        /// </summary>
        /// <param name="product"> Product being upserted </param>
        public async Task Upsert(Product product)
        {
            try
            {
                await _dataAccess.Write<Product>("UpsertProduct", product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Update the price history of a product
        /// </summary>
        /// <param name="id">Product ID to be updated</param>
        /// <param name="price">Current Price for the product</param>
        /// <param name="currentDate">Todays date</param>
        /// <returns></returns>
        public async Task UpdatePrice(string id, decimal price)
        {
            try
            {
                await _dataAccess.Write<dynamic>("UpdatePriceHistory", new
                {
                    NewPrice = price,
                    ProductID = id
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
