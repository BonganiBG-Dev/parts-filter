using PriceHunterFilterAPI.DataAccess.Model;
using PriceHunterFilterAPI.DTOs;
using PriceHunterFilterAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PriceHunterFilterAPI.Filters
{
    public class ProductFilter
    {
        public Product FilterProduct(ProductRaw baseProduct) 
        {
            Product product = new();

            product.Id = GenerateID(baseProduct.Name);
            product.Name = baseProduct.Name;
            product.Image = baseProduct.Image;            
            product.Link = baseProduct.Link;
            product.Site = baseProduct.Site; // Change this to ID
            product.Category = baseProduct.Category; // Change this to ID                        
            product.Price = ConvertPrice(baseProduct.Price);

            return product;
        }

        private string GenerateID(string productName)
        {
            productName = productName.ToLower();
            productName = Regex.Replace(productName, " ", "");

            var bytes = Encoding.ASCII.GetBytes(productName);
            return Convert.ToBase64String(bytes);
        }

        private decimal ConvertPrice(string price)
        {
            price = Regex.Replace(price, @"\D", "");                        
            return Decimal.TryParse(price, out decimal priceDecimal) ? priceDecimal : -1;
            
        }
    }
}
