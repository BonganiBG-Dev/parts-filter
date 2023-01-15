using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.Database.Interfaces
{
    public interface IDatabaseFunctions<T>
    {
        public void Insert(T item);
        public void Update(T item);
        public void Delete(T item);
        public List<T> Get();
        public T Get(string _id);
        
    }
}
