using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PriceHunterFilter.Services
{
    public class PriceFilter
    {
        public double FilterPrice(string input)
        {
            input = RemoveNonNumberCharacters(input);
            return ContainsNumber(input) ? Convert.ToDouble(input) : 0;
        }

        private string RemoveNonNumberCharacters(string input)
        {
            return Regex.Replace(input, @"\D", "");
        }

        private bool ContainsNumber(string input)
        {
            return Regex.Replace(input, @"\D", "").Length > 0 ? true : false;
        }
    }
}
