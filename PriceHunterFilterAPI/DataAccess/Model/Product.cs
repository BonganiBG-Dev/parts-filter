using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilterAPI.DataAccess.Model
{
    public struct Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Site { get; set; }
        public string Category { get; set; }
        public string Link { get; set; }
    }
}
