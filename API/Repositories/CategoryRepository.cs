using PriceHunterFilter.API.models;
using PriceHunterFilter.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.API.Repositories
{
    public class CategoryRepository
    {
        private readonly IDataAccess<Category> _dataAccess;

        public CategoryRepository(IDataAccess<Category> dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<Category> GetCategories()
        {
            return _dataAccess.GetAll();
        }

    }
}
