using BookManagement_BusinessObjects;
using BookManagement_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public class BookRepo : IBookRepo
	{
		public bool AddBook(Book book)
		{
			return BookDAO.Instance.AddBook(book);
		}


		public bool DeleteBook(int id)
		{
			return BookDAO.Instance.DeleteBook(id);
		}
		public Book GetBook(int id)
		{
			return BookDAO.Instance.GetBook(id);
		}
		public List<Book> GetBooks()
		{
			return BookDAO.Instance.GetBooks();
		}
		public bool UpdateBook(Book book)
		{
			return BookDAO.Instance.UpdateBook(book);
		}
	}
}
