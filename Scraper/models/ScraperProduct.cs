using MongoDB.Bson;

namespace PriceHunterFilter
{
    public class ScraperProduct
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Link { get; set; }
        public string Site { get; set; }
        public string Image { get; set; }
        public DateTime Added { get; set; }
        public int __v { get; set; }

    }

}