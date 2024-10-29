using BookManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Repositories
{
	public interface IOrderDetailRepo
	{
		public OrderDetail GetOrderDetail(int id);
		public bool AddOrderDetail(OrderDetail orderDetail);
		public bool DeleteOrderDetail(int id);
		public bool UpdateOrderDetail(OrderDetail orderDetail);
		public List<OrderDetail> GetOrders();
		public List<OrderDetail> GetOrderDetailsByOrderId(int id);
	}
}
