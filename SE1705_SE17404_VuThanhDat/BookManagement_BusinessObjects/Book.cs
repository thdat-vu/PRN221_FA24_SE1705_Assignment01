using System;
using System.Collections.Generic;

namespace BookManagement_BusinessObjects
{
    public partial class Book
    {
        public Book()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
