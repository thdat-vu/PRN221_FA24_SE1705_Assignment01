using System;
using System.Collections.Generic;

namespace BookManagement_BusinessObjects
{
    public partial class Account
    {
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
