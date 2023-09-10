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
            _dataAccess = dataAccess;
        }

        /// <summary>
        /// Updates existing products or creates a new product
        /// </summary>
        /// <param name="product"> Product being upserted </param>
        public void Upsert(Product product)
        {
            if (!Exists(product.Id))
            {
                CreateProduct(product);
                return;
            }

            if (hasPriceChanged(ref product))
                UpdatePrice(product);
        }

        /// <summary>
        /// Check if a product ID is already present in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Exists(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new database record
        /// </summary>
        /// <param name="product"> Product to be inserted </param>        
        private void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the price of an item has changed
        /// </summary>
        /// <param name="product"> item being evaluated </param>
        private bool hasPriceChanged(ref Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the price of the object and creates an entry in the update table
        /// </summary>
        /// <param name="product">Product being updated</param>
        private void UpdatePrice(Product product)
        {
            throw new NotImplementedException();
        }

    }
}
