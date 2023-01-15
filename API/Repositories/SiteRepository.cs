using PriceHunterFilter.API.models;
using PriceHunterFilter.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.API.Repositories
{
    public class SiteRepository
    {

        private readonly IDataAccess<Site> _dataAccess;

        public SiteRepository(IDataAccess<Site> dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<Site> GetSites()
        {
            return _dataAccess.GetAll();
        }
    }
}
