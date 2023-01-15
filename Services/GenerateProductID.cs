using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PriceHunterFilter.Services
{
    public class GenerateProductID
    {
        public string ConvertToLowerCase(string input)
        {
            return input.ToLower();
        }

        public string GetID(string input)
        {
            input = RemoveSpaces(input);
            var bytes = Encoding.ASCII.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        public string RemoveSpaces(string input)
        {
            return Regex.Replace(input, " ", "");

        }
    }
}
