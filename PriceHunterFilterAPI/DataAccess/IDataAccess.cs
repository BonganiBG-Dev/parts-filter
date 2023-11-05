using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilterAPI.DataAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> Read<T, U>(string query, 
                                            U parameters, 
                                            string connectionString = "Default");
        Task Write<T>(string query,
                        T parameters,
                        string connectionString = "Default");
    }
}
