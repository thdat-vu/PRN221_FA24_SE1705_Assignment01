using BookManagement_BusinessObjects;
using BookManagement_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo orderRepo;

        public OrderService()
        {
            orderRepo = new OrderRepo();
        }

        public bool AddOrder(Order order)
        {
            return orderRepo.AddOrder(order);
        }

        public bool CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            return orderRepo.CreateOrder(order, orderDetails);
        }

        public bool DeleteOrder(int id)
        {
            return orderRepo.DeleteOrder(id);
        }

        public Order GetOrder(int id)
        {
            return orderRepo.GetOrder(id);
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return orderRepo.GetOrderDetails(orderId);
        }

        public List<Order> GetOrders()
        {
            return orderRepo.GetOrders();
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return orderRepo.GetOrdersByUserId(userId);
        }

        public bool UpdateOrder(Order order)
        {
            return orderRepo.UpdateOrder(order);
        }
    }
}
