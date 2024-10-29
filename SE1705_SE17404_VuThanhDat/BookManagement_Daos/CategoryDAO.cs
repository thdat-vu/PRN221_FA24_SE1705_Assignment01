using BookManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Daos
{
	public class CategoryDAO
	{
		private static CategoryDAO instance = null;
		private BookManagementContext context;
		public static CategoryDAO Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new CategoryDAO();
				}
				return instance;
			}
		}
		public CategoryDAO()
		{
			context = new BookManagementContext();
		}

		public List<Category> GetCategories() => context.Categories.ToList();
		public Category GetCategory(int id) => context.Categories.SingleOrDefault(c => c.Id == id);

	}
}
