using BookManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Daos
{
	public class BookDAO
	{
		private BookManagementContext context;
		private static BookDAO instance = null;
		public static BookDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BookDAO();
				}
				return instance;
			}
			
		}

        public BookDAO()
        {
            context = new BookManagementContext();
        }
        public List<Book> GetBooks() => context.Books.ToList();
		public Book GetBook(int id) => context.Books.SingleOrDefault(b => b.Id == id);

		public bool AddBook(Book book)
		{
			bool isSuccess = false;
			try
			{
				context.Books.Add(book);
				context.SaveChanges();
				isSuccess = true;
			}
			catch (Exception ex)
			{

			}
			return isSuccess;
		}
		public bool DeleteBook(int id)
		{
			bool isSuccess = false;
			try
			{
				context.Books.Remove(GetBook(id));
				context.SaveChanges();
				isSuccess = true;
			}
			catch (Exception ex)
			{

			}
			return isSuccess;
		}

		public bool UpdateBook(Book book)
		{
			bool isSuccess = false;
			try
			{
				Book chosenBook = GetBook(book.Id);
				if (chosenBook != null)
				{
					context.Entry(chosenBook).CurrentValues.SetValues(book);
					context.SaveChanges();
					isSuccess = true;
				}
			}
			catch (Exception ex)
			{

			} return isSuccess;
		}
	}
}
