using BookManagement_BusinessObjects;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Daos
{
	public class OrderDetailDAO
	{
		private BookManagementContext context;
		private static OrderDetailDAO instance = null;

		public static OrderDetailDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new OrderDetailDAO();
				}
				return instance;
			}

		}
		public OrderDetailDAO() 
		{
			context = new BookManagementContext();	
		}

		// Get a specific OrderDetail by its Id
		public OrderDetail GetOrderDetail(int id) => context.OrderDetails.SingleOrDefault(od => od.Id == id);

		// Get all OrderDetails
		public List<OrderDetail> GetOrderDetails() => context.OrderDetails.ToList();

		// Get OrderDetails by OrderId (useful when displaying details for a specific order)
		public List<OrderDetail> GetOrderDetailsByOrderId(int orderId) => context.OrderDetails.Where(od => od.OrderId == orderId).ToList();

		// Add a new OrderDetail
		public bool AddOrderDetail(OrderDetail orderDetail)
		{
			bool isSuccess = false;
			if (orderDetail != null)
			{
				context.OrderDetails.Add(orderDetail);
				context.SaveChanges();
				isSuccess = true;
			}
			return isSuccess;
		}

		// Update an existing OrderDetail
		public bool UpdateOrderDetail(OrderDetail orderDetail)
		{
			bool isSuccess = false;
			OrderDetail chosenOrderDetail = GetOrderDetail(orderDetail.Id);
			if (chosenOrderDetail != null)
			{
				context.Entry(chosenOrderDetail).CurrentValues.SetValues(orderDetail);
				context.SaveChanges();
				isSuccess = true;
			}
			return isSuccess;
		}

		// Delete an OrderDetail by its Id
		public bool DeleteOrderDetail(int id)
		{
			bool isSuccess = false;
			OrderDetail orderDetail = GetOrderDetail(id);
			if (orderDetail != null)
			{
				context.OrderDetails.Remove(orderDetail);
				context.SaveChanges();
				isSuccess = true;
			}
			return isSuccess;
		}
	}
}

