using MongoDB.Bson;
using MongoDB.Driver;
using PriceHunterFilter.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.Database
{
    public class DataAccess<T> : IDataAccess<T>
    {
        public string CollectionName { get; set; }

        private readonly IMongoConnection _connection;

        public DataAccess(IMongoConnection connection, string collectionName)
        {
            _connection = connection;
            _connection.SetConnection();
            CollectionName = collectionName;
        }

        public bool Create(T data, dynamic id)
        {
            if (Exists(id))
                return false;
            
            _connection.Database.GetCollection<T>(CollectionName).InsertOne(data);
                return true;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            _connection.Database.GetCollection<T>(CollectionName).DeleteOne(filter);

            return true;
        }

        public bool Exists(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return _connection.Database.GetCollection<T>(CollectionName).Find<T>(filter).Count() > 0;
        }

        public bool Exists(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return _connection.Database.GetCollection<T>(CollectionName)
                .Find<T>(new BsonDocument())
                .ToList<T>();
        }

        public T Get(string id, FilterDefinition<T> filter = null)
        {
            if (filter == null)
                filter = Builders<T>.Filter.Eq("_id", id);

            T item = _connection.Database.GetCollection<T>(CollectionName).Find<T>(filter).FirstOrDefault();
            return item;
        }

        public List<T> Get(FilterDefinition<T> filter)
        {
            return _connection.Database.GetCollection<T>(CollectionName).Find<T>(filter).ToList<T>();
        }

        public bool Update(T data, string id)
        {

            if (!Exists(id))
                return false;

            var filter = Builders<T>.Filter.Eq("_id", id);
            _connection.Database.GetCollection<T>(CollectionName).ReplaceOne(filter, data);

            return true;
        }
    }
}
