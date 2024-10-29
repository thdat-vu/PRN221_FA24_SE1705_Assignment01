using BookManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public interface IBookRepo
	{
		public Book GetBook(int id);
		public List<Book> GetBooks();
		public bool AddBook (Book book);
		public bool UpdateBook (Book book);
		public bool DeleteBook (int id);
	}
}
