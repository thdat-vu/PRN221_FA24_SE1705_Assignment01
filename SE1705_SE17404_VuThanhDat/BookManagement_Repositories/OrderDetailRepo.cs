using BookManagement_BusinessObjects;
using BookManagement_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public class OrderDetailRepo : IOrderDetailRepo
	{
		public bool AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddOrderDetail(orderDetail);
		public bool DeleteOrderDetail(int id) => OrderDetailDAO.Instance.DeleteOrderDetail(id);

		public OrderDetail GetOrderDetail(int id) => OrderDetailDAO.Instance.GetOrderDetail(id);

		public List<OrderDetail> GetOrderDetailsByOrderId(int orderId) => OrderDetailDAO.Instance.GetOrderDetailsByOrderId(orderId);
		public List<OrderDetail> GetOrders() => OrderDetailDAO.Instance.GetOrderDetails();

		public bool UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
	}
}
