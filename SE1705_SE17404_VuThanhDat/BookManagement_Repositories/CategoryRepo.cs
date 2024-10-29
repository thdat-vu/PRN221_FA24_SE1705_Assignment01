using BookManagement_BusinessObjects;
using BookManagement_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public class CategoryRepo : ICategoryRepo
	{
		public List<Category> GetCategories() => CategoryDAO.Instance.GetCategories();

		public Category GetCategory(int id) => CategoryDAO.Instance.GetCategory(id);
	}
}
