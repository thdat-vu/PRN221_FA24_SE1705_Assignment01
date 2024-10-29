using BookManagement_BusinessObjects;
using BookManagement_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Services
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepo accountRepo;

        public AccountService()
        {
            accountRepo = new AccountRepo();
        }
        public Account GetAccount(string username)
        {
            return accountRepo.GetAccount(username);
        }
	}
}
