using PriceHunterFilterAPI.Extensions;
using PriceHunterFilterAPI.Models;
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
        public Product FilterProduct(DataAccess.Model.Product baseProduct) 
        {
            Product product = new();

            product.Id = GenerateID(baseProduct.Name);
            product.Name = baseProduct.Name;
            product.Image = baseProduct.Image;            
            product.Link = baseProduct.Link;
            product.Site = baseProduct.Site.GetSite();
            product.Category = baseProduct.Category.GetCategory();

            return product;
        }

        private string GenerateID(string productName)
        {
            productName = productName.ToLower();
            productName = Regex.Replace(productName, " ", "");

            var bytes = Encoding.ASCII.GetBytes(productName);
            return Convert.ToBase64String(bytes);
        }
    }
}
