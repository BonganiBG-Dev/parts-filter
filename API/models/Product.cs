namespace PriceHunterFilter.API.models
{
    public class Product
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Category_id { get; set; }
        public string Site_id { get; set; }
        public string Img_url { get; set; }
        public string Page_link { get; set; }
        public string Series_id { get; set; }
        public double Price { get; set; }
        public DateTime Last_updated { get; set; }
        public List<PriceHistory> Price_history { get; set; }
        public int __v { get; set; }
    }
}