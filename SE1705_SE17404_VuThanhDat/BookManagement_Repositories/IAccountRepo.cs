using BookManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public interface IAccountRepo
	{
		public Account GetAccount(string username);
	}
}
