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
	/// Interaction logic for AdminWindow.xaml
	/// </summary>
	public partial class AdminWindow : Window
	{
		private IBookService bookService;
		private ICategoryService categoryService;
		public AdminWindow()
		{
			InitializeComponent();
			bookService = new BookService();
			categoryService = new CategorySerivce();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadInitData();
			LoadCategory();
        }

		private void LoadInitData()
		{
			dgBook.ItemsSource = bookService.GetBooks();
		}

        private void btnClose_click(object sender, RoutedEventArgs e)
        {
			this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
			Book book = new Book();
			book.Title = this.txtTitle.Text;
			book.Author = this.txtAuthor.Text;
			book.Price = int.Parse(this.TxtPrice.Text);
			book.CategoryId = int.Parse(cboCategory.SelectedValue.ToString());

			if (bookService.AddBook(book))
			{
				MessageBox.Show("Added successfully");
				LoadInitData();
                ClearFields();
            }
			else
			{
                MessageBox.Show("Error!");
                ClearFields();
            }
        }

		public void LoadCategory()
		{
			try
			{
				var categoryList = categoryService.GetCategories();
				cboCategory.ItemsSource = categoryList;
				cboCategory.DisplayMemberPath = "Name";
				cboCategory.SelectedValuePath = "Id";

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void dgBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBook.SelectedItem is Book selectedBook)
            {
                // Set the selected book's details to the fields
                txtTitle.Text = selectedBook.Title;
                txtAuthor.Text = selectedBook.Author;
                TxtPrice.Text = selectedBook.Price.ToString();
                cboCategory.SelectedValue = selectedBook.CategoryId;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgBook.SelectedItem is Book selectedBook)
            {
                // Update the selected book with the current data in the text fields
                selectedBook.Title = txtTitle.Text;
                selectedBook.Author = txtAuthor.Text;
                selectedBook.Price = decimal.Parse(TxtPrice.Text);
                selectedBook.CategoryId = (int)cboCategory.SelectedValue;

                // Save changes via the service
                if (bookService.UpdateBook(selectedBook))
                {
                    MessageBox.Show("Updated successfully");
                    LoadInitData();  // Refresh DataGrid
                    ClearFields();    // Clear input fields
                }
                else
                {
                    MessageBox.Show("Error updating the book!");
                }
            }
            else
            {
                MessageBox.Show("Please select a book to update.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgBook.SelectedItem is Book selectedBook)
            {
                // Confirm delete operation
                var result = MessageBox.Show("Are you sure you want to delete this book?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Delete the book via the service
                    if (bookService.DeleteBook(selectedBook.Id))
                    {
                        MessageBox.Show("Deleted successfully");
                        LoadInitData();  // Refresh DataGrid
                        ClearFields();    // Clear input fields
                    }
                    else
                    {
                        MessageBox.Show("Error deleting the book!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.");
            }   
        }

        private void ClearFields()
        {
            txtTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            cboCategory.SelectedIndex = 0;
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            AdminOrderWindow adminOrderWindow = new AdminOrderWindow();
            adminOrderWindow.Show();
        }
    }
}
