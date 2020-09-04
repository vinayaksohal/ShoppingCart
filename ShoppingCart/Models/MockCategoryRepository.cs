using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => new List<Category>()
        {
            new Category
            {
                CategoryId=101,
                Name="web technology",
                Description="Server/Client side courses"
            },
            new Category
            {
                CategoryId=102,
                Name="Data Science",
                Description="Data Science courses"
            },
            new Category
            {
                CategoryId=103,
                Name="Mobile Application Development",
                Description="Courses related to mobile application development"
            }
        };
    }
}

