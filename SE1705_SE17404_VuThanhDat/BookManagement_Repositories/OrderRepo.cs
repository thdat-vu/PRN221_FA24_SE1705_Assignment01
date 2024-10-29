using BookManagement_BusinessObjects;
using BookManagement_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public class OrderRepo : IOrderRepo
	{
		public bool AddOrder(Order order) => OrderDAO.Instance.AddOrder(order);

        public bool CreateOrder(Order order, List<OrderDetail> orderDetails) => OrderDAO.Instance.CreateOrder(order, orderDetails);

        public bool DeleteOrder(int id) => OrderDAO.Instance.DeleteOrder(id);

		public Order GetOrder(int id) => OrderDAO.Instance.GetOrder(id);

        public List<OrderDetail> GetOrderDetails(int orderId) => OrderDAO.Instance.GetOrderDetails(orderId);

        public List<Order> GetOrders() => OrderDAO.Instance.GetOrders();

        public List<Order> GetOrdersByUserId(int userId) => OrderDAO.Instance.GetOrdersByUserId(userId);

        public bool UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);


	}
}
