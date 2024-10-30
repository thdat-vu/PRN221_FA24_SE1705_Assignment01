using BookManagement_BusinessObjects;
using BookManagement_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab01_BookManagement
{
    /// <summary>
    /// Interaction logic for AdminOrderWindow.xaml
    /// </summary>
    public partial class AdminOrderWindow : Window
    {
        private IOrderService orderService;
        private IOrderDetailService orderDetailService;
        public AdminOrderWindow()
        {
            InitializeComponent();
            orderService = new OrderService();
            orderDetailService = new OrderDetailService();
        }

        private void btnEditOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            //if (dgOrderDetail.SelectedItem is OrderDetail selectedOrderDetail)
            //{
            //    // Prompt the user for a new quantity and price
            //    int newQuantity = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter new quantity:", "Edit Order Detail", selectedOrderDetail.Quantity.ToString()));
            //    decimal newPrice = decimal.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter new price:", "Edit Order Detail", selectedOrderDetail.Price.ToString()));

            //    selectedOrderDetail.Quantity = newQuantity;
            //    selectedOrderDetail.Price = newPrice;

            //    if (orderDetailService.UpdateOrderDetail(selectedOrderDetail))
            //    {
            //        MessageBox.Show("Order detail updated successfully.");
            //        LoadOrderDetails(selectedOrderDetail.OrderId);  // Refresh order details

            //        // Update the order's total amount
            //        UpdateOrderTotalAmount(selectedOrderDetail.OrderId);
            //        LoadOrders();  // Refresh the order list to show the updated total amount
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error updating order detail.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select an order detail to edit.");
            //}

            if (dgOrderDetail.SelectedItem is OrderDetail selectedOrderDetail)
            {
                // Open the custom dialog with initial quantity and price values
                var dialog = new EditOrderDetailDialog(selectedOrderDetail.Quantity, selectedOrderDetail.Price);

                // Show dialog and process only if the user clicks OK
                if (dialog.ShowDialog() == true)
                {
                    selectedOrderDetail.Quantity = dialog.Quantity.Value;
                    selectedOrderDetail.Price = dialog.Price.Value;

                    // Save the updated order detail
                    if (orderDetailService.UpdateOrderDetail(selectedOrderDetail))
                    {
                        MessageBox.Show("Order detail updated successfully.");
                        LoadOrderDetails(selectedOrderDetail.OrderId);  // Refresh order details

                        // Update the order's total amount
                        UpdateOrderTotalAmount(selectedOrderDetail.OrderId);
                        LoadOrders();  // Refresh the order list to show the updated total amount
                    }
                    else
                    {
                        MessageBox.Show("Error updating order detail.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order detail to edit.");
            }
        }

        private void btnDeleteOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrderDetail.SelectedItem is OrderDetail selectedOrderDetail)
            {
                var result = MessageBox.Show("Are you sure you want to delete this order detail?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (orderDetailService.DeleteOrderDetail(selectedOrderDetail.Id))
                    {
                        MessageBox.Show("Order detail deleted successfully.");
                        LoadOrderDetails(selectedOrderDetail.OrderId);  // Refresh order details

                        // Update the order's total amount
                        UpdateOrderTotalAmount(selectedOrderDetail.OrderId);
                        LoadOrders();  // Refresh the order list to show the updated total amount
                    }
                    else
                    {
                        MessageBox.Show("Error deleting order detail.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order detail to delete.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgOrder.SelectedItem is Order selectedOrder)
            {
                LoadOrderDetails(selectedOrder.Id);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadOrders();
            
        }

        private void LoadOrders()
        {
            dgOrder.ItemsSource = orderService.GetOrders();
        }
        private void LoadOrderDetails(int orderId)
        {
            dgOrderDetail.ItemsSource = orderDetailService.GetOrderDetailsByOrderId(orderId);
        }

        private void UpdateOrderTotalAmount(int orderId)
        {
            // Get all order details for the specified order
            var orderDetails = orderDetailService.GetOrderDetailsByOrderId(orderId);

            // Calculate the new total amount
            decimal newTotalAmount = orderDetails.Sum(detail => detail.Quantity * detail.Price);

            // Update the order with the new total amount
            Order orderToUpdate = orderService.GetOrder(orderId);
            orderToUpdate.TotalAmount = newTotalAmount;

            // Save the updated order
            orderService.UpdateOrder(orderToUpdate);
        }
    }
}
