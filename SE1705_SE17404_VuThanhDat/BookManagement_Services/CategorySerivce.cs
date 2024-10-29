using BookManagement_BusinessObjects;
using BookManagement_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Services
{
    public class CategorySerivce : ICategoryService
    {
        private readonly ICategoryRepo categoryRepo;
        public CategorySerivce()
        {
            categoryRepo = new CategoryRepo();
        }
        public List<Category> GetCategories()
        {
            return categoryRepo.GetCategories();
        }

        public Category GetCategory(int id)
        {
            return categoryRepo.GetCategory(id);
        }
    }
}
