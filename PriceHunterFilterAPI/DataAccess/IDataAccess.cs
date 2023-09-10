using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilterAPI.DataAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string query, 
                                            U parameters, 
                                            string connectionString = "Default");
        Task SaveData<T>(string query,
                        T parameters,
                        string connectionString = "Default");
    }
}
