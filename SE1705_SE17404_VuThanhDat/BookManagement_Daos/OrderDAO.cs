using BookManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Daos
{
	public class OrderDAO
	{
		private BookManagementContext context;
		private static OrderDAO instance = null;
		public static OrderDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new OrderDAO();
				}
				return instance;

			}
		}
        public OrderDAO()
        {
            context = new BookManagementContext();	
        }

		public Order GetOrder(int id) => context.Orders.SingleOrDefault(o => o.Id == id);
		public List<Order> GetOrders() => context.Orders.ToList();

        public List<Order> GetOrdersByUserId(int userId)
        {
            return context.Orders
                           .Where(o => o.AccountId == userId)
                           .ToList();
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            //return context.OrderDetails
            //               .Include(od => od.Book) // To retrieve book details like title, if needed
            //               .Where(od => od.OrderId == orderId)
            //               .Select(od => new OrderDetail
            //               {
            //                   Id = od.Id,
            //                   OrderId = od.OrderId,
            //                   BookId = od.BookId,
            //                   Quantity = od.Quantity,
            //                   Price = od.Price,
            //                   // BookTitle = od.Book.Title 
            //               })
            //               .ToList();

            var orderDetails = (from od in context.OrderDetails
                                join b in context.Books on od.BookId equals b.Id
                                where od.OrderId == orderId
                                select new OrderDetail
                                {
                                    Id = od.Id,
                                    OrderId = od.OrderId,
                                    BookId = od.BookId,
                                    Quantity = od.Quantity,
                                    Price = od.Price,
                                    BookTitle = b.Title // Fetch BookTitle here
                                }).ToList();

            return orderDetails;
        }

        public bool CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            bool result = false;
            using var transaction = context.Database.BeginTransaction();

            try
            {
                // Add the order to the database
                context.Orders.Add(order);
                context.SaveChanges();

                // Set the OrderId for each OrderDetail and add to database
                foreach (var detail in orderDetails)
                {
                    detail.OrderId = order.Id; // Set the generated OrderId
                    context.OrderDetails.Add(detail);
                }

                // Calculate total amount based on order details
                order.TotalAmount = orderDetails.Sum(d => d.Quantity * d.Price);

                // Update the order with the new total amount and save changes
                context.Orders.Update(order);
                context.SaveChanges();

                // Commit transaction
                transaction.Commit();

                result = true;
            }
            catch (Exception)
            {
                // Rollback transaction if an error occurs
                transaction.Rollback();
                result = false;
            }
            return result;
        }
    
        public bool AddOrder(Order order)
		{
			bool isSuccess = false;
			if (order != null)
			{
				context.Orders.Add(order);
				context.SaveChanges();
				isSuccess = true;
			}
			return isSuccess;

		}
		public bool DeleteOrder(int id)
		{
			bool isSuccess = false;
			Order order = GetOrder(id);
			if (order != null)
			{
				context.Orders.Remove(order);
				context.SaveChanges();
				isSuccess = true;
			}
			return isSuccess;
		}

		public bool UpdateOrder(Order order)
		{
			bool isSuccess = false;
			Order chosenOrder = GetOrder(order.Id);
			if (chosenOrder != null)
			{
				context.Entry(chosenOrder).CurrentValues.SetValues(order);
				context.SaveChanges();
				isSuccess = true;
			}
			return isSuccess;
		}
	}
}
