using System;
using System.Collections.Generic;

namespace BookManagement_BusinessObjects
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        // New property to store book title
        public string BookTitle { get; set; }
        public virtual Book Book { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
