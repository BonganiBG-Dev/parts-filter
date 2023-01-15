using PriceHunterFilter.API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.Services
{
    public class SiteFilterService
    {
        private readonly List<Site> sites;

        public SiteFilterService(List<Site> sites)
        {
            this.sites = sites;
        }

        public string GetSiteId(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "NONE";

            var value = sites.Find(item => item.Name == name);

            return value is null ? name : value._id;
        }
    }
}
