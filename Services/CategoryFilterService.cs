using PriceHunterFilter.API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.Services
{
    public class CategoryFilterService
    {
        private readonly List<Category> categories;

        public CategoryFilterService(List<Category> categories)
        {
            this.categories = categories;
        }

        public string GetCategoryId(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "NONE";

            var value = categories.Find(item => item.Name.Equals(name));
            return value is null ? name : value._id;
        }
    }
}
