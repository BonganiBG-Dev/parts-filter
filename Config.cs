using PriceHunterFilter.API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter
{
    public static class Config
    {
        public static string MONGO_CLIENT { get; set; } = "mongodb://localhost:27017";
        public static string DATABASE_NAME { get; set; } = "Price-Hunter-Holder-Test";

        public static string SCRAPER_COLLECTION { get; set; } = "holders";
        public static string API_COLLECTION { get; set; } = "products";
        public static string SITE_COLLECTION { get; set; } = "sites";
        public static string CATEGORY_COLLECTION { get; set; } = "categories";


        public static List<Category> CATEGORIES { get; set; } = new List<Category>();
        public static List<Site> WEBSITES { get; set; } = new();
    }
}