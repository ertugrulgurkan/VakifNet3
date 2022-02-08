using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Services
{
    public class CategoryService : ICategoryService
    {
        private List<Category> categories = new List<Category>
        {
            new Category{ Id =1, Name="Category A"},
            new Category{ Id =2, Name="Category B"},
            new Category{ Id =1, Name="Category C"}

        };
        public List<Category> GetCategories()
        {
            return categories;
        }
    }
}
