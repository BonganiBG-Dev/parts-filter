using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilterAPI.DataAccess
{
    public class SqlAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;
        
        public SqlAccess(IConfiguration configuration)
        {
            Console.WriteLine("We are in the SQL service");
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> Read<T, U>(string query, U parameters, 
            string connectionString = "Default")
        {
            using IDbConnection connection = new SqlConnection(
                _configuration.GetConnectionString(connectionString));

            return await connection.QueryAsync<T>(query, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task Write<T>(string query, T parameters, string connectionString = "Default")
        {
            using IDbConnection connection = new SqlConnection(
                _configuration.GetConnectionString(connectionString));

            await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
