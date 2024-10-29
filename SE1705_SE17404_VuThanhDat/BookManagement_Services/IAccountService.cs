using BookManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Services
{
	public interface IAccountService
	{
		public Account GetAccount(string username);
	}
}
