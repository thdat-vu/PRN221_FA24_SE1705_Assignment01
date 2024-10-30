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
    /// Interaction logic for EditOrderDetailDialog.xaml
    /// </summary>
    public partial class EditOrderDetailDialog : Window
    {

        public int? Quantity { get; private set; }
        public decimal? Price { get; private set; }

        public EditOrderDetailDialog(int initialQuantity, decimal initialPrice)
        {
            InitializeComponent();
            txtQuantity.Text = initialQuantity.ToString();
            txtPrice.Text = initialPrice.ToString();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            // Validate and parse input for Quantity
            if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
            {
                Quantity = quantity;
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            // Validate and parse input for Price
            if (decimal.TryParse(txtPrice.Text, out decimal price) && price >= 0)
            {
                Price = price;
            }
            else
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
