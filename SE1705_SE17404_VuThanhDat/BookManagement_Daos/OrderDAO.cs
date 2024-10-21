using BookManagement_BusinessObjects;
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
		public OrderDAO Instance
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
