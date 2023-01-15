namespace PriceHunterFilter.API.models
{
    public class Category
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public List<string> product_ids { get; set; }
        public List<string> series_ids { get; set; }
    }
}