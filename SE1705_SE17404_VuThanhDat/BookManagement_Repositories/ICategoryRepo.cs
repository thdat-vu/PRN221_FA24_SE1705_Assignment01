using BookManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public interface ICategoryRepo
	{
		public Category GetCategory(int id);
		public List<Category> GetCategories();
	}
}
