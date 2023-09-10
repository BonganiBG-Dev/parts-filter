using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PriceHunterFilterAPI.Services
{
    public class RabbitMqConsumer : IConsumer
    {
        public T Get<T>()
        {
            string jsonObject = GetMessage();      
            
            if (TryDeserialize<T>(jsonObject, out T result))            
                return result;

            throw new Exception("Incorrect Format");
        }

        /// <summary>
        /// consume the data from RabbitMQ
        /// </summary>
        /// <returns>The json string for the object</returns>
        private string GetMessage()
        {
            throw new NotImplementedException();
        }        


        private bool TryDeserialize<T>(string jsonObject, out T dataObj)
        {
            bool assigned = false;

            try
            {
                dataObj = JsonSerializer.Deserialize<T>(jsonObject);
                assigned = true;
            }
            catch (Exception)
            {
                dataObj = default(T);
                // Log the error
            }

            return assigned;
        }
    }
}
