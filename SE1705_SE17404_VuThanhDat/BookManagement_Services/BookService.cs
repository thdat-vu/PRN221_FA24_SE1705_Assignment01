using BookManagement_BusinessObjects;
using BookManagement_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Services
{
	public class BookService : IBookService
	{
		private readonly IBookRepo bookRepo;
		
		public BookService()
		{
			this.bookRepo = new BookRepo();
		}
		public bool AddBook(Book book)
		{
			return bookRepo.AddBook(book);
		}

		public bool DeleteBook(int id)
		{
			return bookRepo.DeleteBook(id);
		}

		public Book GetBook(int id)
		{
			return bookRepo.GetBook(id);
		}

		public List<Book> GetBooks()
		{
			return bookRepo.GetBooks();
		}

		public bool UpdateBook(Book book)
		{
			return bookRepo.UpdateBook(book);
		}
	}
}
