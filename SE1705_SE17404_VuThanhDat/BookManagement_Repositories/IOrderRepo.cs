using BookManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public interface IOrderRepo
	{
		public Order GetOrder(int id);
		public List<Order> GetOrders();
		public bool AddOrder (Order order);
		public bool DeleteOrder (int id);
		public bool UpdateOrder (Order order);

		public List<Order> GetOrdersByUserId(int userId);
		public List<OrderDetail> GetOrderDetails(int orderId);
		public bool CreateOrder(Order order, List<OrderDetail> orderDetails);


    }
}
