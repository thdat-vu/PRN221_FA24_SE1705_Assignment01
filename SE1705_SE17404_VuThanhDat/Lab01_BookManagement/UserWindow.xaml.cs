using BookManagement_BusinessObjects;
using BookManagement_BusinessObjects.ViewModel;
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
	/// Interaction logic for UserWindow.xaml
	/// </summary>
	public partial class UserWindow : Window
	{
        private readonly IOrderService orderService;
        private readonly IBookService bookService;
        private List<OrderDetail> newOrderDetails;
        private List<OrderDetailViewModel> newOrderDetailViewModels;
        private int userId;
        public UserWindow(int userId)
		{
			InitializeComponent();
            orderService = new OrderService();
            bookService = new BookService();
            this.userId = userId;
            newOrderDetails = new List<OrderDetail>();
            newOrderDetailViewModels = new List<OrderDetailViewModel>();
            LoadUserOrders();
            LoadBooks();
        }

        private void LoadUserOrders()
        {
            var userOrders = orderService.GetOrdersByUserId(userId);
            dgUserOrders.ItemsSource = userOrders;
        }

        private void LoadBooks()
        {
            cboBooks.ItemsSource = bookService.GetBooks();
            cboBooks.SelectedValuePath = "Id";
            cboBooks.DisplayMemberPath = "Title";

        }

        private void dgUserOrders_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgUserOrders.SelectedItem is Order selectedOrder)
            {
                //var orderDetails = orderService.GetOrderDetails(selectedOrder.Id);
                //dgOrderDetails.ItemsSource = orderDetails;

                // Fetch the raw order details for the selected order
                var orderDetails = orderService.GetOrderDetails(selectedOrder.Id);

                // Transform order details to OrderDetailViewModel
                var orderDetailViewModels = orderDetails.Select(detail =>
                {
                    var book = bookService.GetBook(detail.BookId); // Fetch book title based on BookId
                    return new OrderDetailViewModel
                    {
                        BookTitle = book?.Title ?? "Unknown", // Use "Unknown" if book not found
                        Quantity = detail.Quantity,
                        Price = detail.Price
                    };
                }).ToList();

                // Set the transformed list as the ItemsSource for the order details DataGrid
                dgOrderDetails.ItemsSource = orderDetailViewModels;
            }
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (cboBooks.SelectedItem is Book selectedBook && int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
            {
                var orderDetail = new OrderDetail
                {
                    BookId = selectedBook.Id,
                    Quantity = quantity,
                    Price = selectedBook.Price,
                    // BookTitle = selectedBook.Title // Assuming this is a display property in OrderDetail
                };

                // Create an OrderDetailViewModel with the BookTitle
                var orderDetailViewModel = new OrderDetailViewModel
                {
                    BookTitle = selectedBook.Title,
                    Quantity = quantity,
                    Price = selectedBook.Price
                };
                newOrderDetails.Add(orderDetail);
                newOrderDetailViewModels.Add(orderDetailViewModel);
                dgOrderDetails.ItemsSource = null; // Refresh the DataGrid view
                //dgOrderDetails.ItemsSource = newOrderDetails;
                dgOrderDetails.ItemsSource = newOrderDetailViewModels;
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Please select a book and enter a valid quantity.");
            }
        }

        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (newOrderDetails.Count == 0)
            {
                MessageBox.Show("No books added to the order.");
                return;
            }

            var newOrder = new Order
            {
                AccountId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = newOrderDetails.Sum(detail => detail.Quantity * detail.Price)
            };

            if (orderService.CreateOrder(newOrder, newOrderDetails))
            {
                MessageBox.Show("Order placed successfully.");
                newOrderDetails.Clear();
                dgOrderDetails.ItemsSource = null; // Clear order details view
                LoadUserOrders(); // Refresh the user's orders
            }
            else
            {
                MessageBox.Show("Failed to place order.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
