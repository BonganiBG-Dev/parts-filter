using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilterAPI.DTOs
{
    public class ProductRaw
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Price { get; set; }
        public required string Image { get; set; }
        public required string Site { get; set; }
        public required string Category { get; set; }
        public required string Link { get; set; }
    }
}
