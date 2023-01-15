using MongoDB.Driver;
using PriceHunterFilter.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.Database
{
    public class MongoConnection : IMongoConnection
    {
        public MongoClient Client { get; internal set; }

        public IMongoDatabase Database { get; internal set; }

        private string _client;
        private string _database;

        public MongoConnection()
        {

        }

        public MongoConnection(string client, string database)
        {
            _client = client;
            _database = database;
        }


        public void Close()
        {
            throw new NotImplementedException();
        }

        public void SetConnection( string client, string database)
        {
            _client= client;
            _database= database;

            SetConnection();
        }

        public void SetConnection()
        {
            Client = new MongoClient(_client);
            Database = Client.GetDatabase(_database);
        }
    }
}
