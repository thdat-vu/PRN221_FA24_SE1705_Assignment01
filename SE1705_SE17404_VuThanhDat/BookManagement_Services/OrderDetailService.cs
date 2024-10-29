using BookManagement_BusinessObjects;
using BookManagement_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepo orderDetailRepo;
        public OrderDetailService()
        {
            orderDetailRepo = new OrderDetailRepo();
        }
        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            return orderDetailRepo.AddOrderDetail(orderDetail);
        }

        public bool DeleteOrderDetail(int id)
        {
            return orderDetailRepo.DeleteOrderDetail(id);
        }

        public OrderDetail GetOrderDetail(int id)
        {
            return orderDetailRepo.GetOrderDetail(id);
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int id)
        {
            return orderDetailRepo.GetOrderDetailsByOrderId(id);
        }

        public List<OrderDetail> GetOrders()
        {
            return orderDetailRepo.GetOrders();
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            return orderDetailRepo.UpdateOrderDetail(orderDetail);
        }
    }
}
