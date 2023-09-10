using PriceHunterFilterAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilterAPI.Extensions
{
    public static class EnumExtensions
    {
        public static Category GetCategory(this string category)
        {
            switch(category.ToLower())
            {
                case "graphics card": return Category.Graphics;
                case "processors": return Category.Processor;
                case "memory": return Category.Memory;
                case "cpu cooler": return Category.Cooler;
                case "case": return Category.Case;
                case "case fans": return Category.Fans;
                case "hard drive": return Category.HDD;
                case "solid state drive": return Category.SSD;
                case "monitor": return Category.Monitor;
                case "motherboard": return Category.Motherboard;
                case "power suppy": return Category.PSU;
                default: 
                    throw new Exception("Item does not exist");
            }
        }

        public static string GetCategoryId(this Category category)
        {
            throw new NotImplementedException();
        }

        public static Site GetSite(this string site)
        {
            switch(site.ToLower())
            {
                case "evetech": return Site.Evetech;
                case "dreamware": return Site.Dreamware;
                case "titan-ice": return Site.Titan;
                default:
                    throw new Exception("Site does not exist");
            }
        }

        public static string GetSiteId(this Site site)
        {
            throw new NotImplementedException();
        }        
    }
}
