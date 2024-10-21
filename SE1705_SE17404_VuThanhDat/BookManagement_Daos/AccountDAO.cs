using BookManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Daos
{
	public class AccountDAO
	{
		private BookManagementContext context;
		private static AccountDAO instance = null;
		public static AccountDAO Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new AccountDAO();
				}
				return instance;
			}
		}
		public AccountDAO() 
		{
			context = new BookManagementContext();
		}

		public Account GetAccount(int username) => context.Accounts.SingleOrDefault(a => a.Username.Equals(username));
	}
}
