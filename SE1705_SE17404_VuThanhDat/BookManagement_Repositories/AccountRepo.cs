using BookManagement_BusinessObjects;
using BookManagement_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public class AccountRepo : IAccountRepo
	{
		public Account GetAccount(string username)
		{
			return AccountDAO.Instance.GetAccount(username);
		}
	}
}
