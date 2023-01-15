using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.Database.Interfaces
{
    public interface IDataAccess<T>
    {
        public T Get(string id, FilterDefinition<T> filter = null);
        public List<T> GetAll();
        public List<T> Get(FilterDefinition<T> filter);
        public bool Create(T data, dynamic id);
        public bool Delete(string id);
        public bool Delete(ObjectId id);
        public bool Exists(string id);
        public bool Exists(ObjectId id);
        public bool Update(T data, string id);
    }
}
