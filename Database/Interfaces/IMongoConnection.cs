using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace PriceHunterFilter.Database.Interfaces
{
    public interface IMongoConnection
    {
        public MongoClient Client { get; }
        public IMongoDatabase Database { get; }

        public void SetConnection(string client, string database);
        public void SetConnection();
        public void Close();

        
    }
}
