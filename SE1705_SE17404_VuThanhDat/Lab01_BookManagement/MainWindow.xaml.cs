using BookManagement_BusinessObjects;
using BookManagement_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab01_BookManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAccountService iaccountService;
        public MainWindow()
        {
            InitializeComponent();
            iaccountService = new AccountService();
        }

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			Account account = iaccountService.GetAccount(txtUsername.Text);
			if (account != null && txtPassword.Password.Equals(account.Password) && account.Role.Equals("Admin"))
			{
				AdminWindow adminWindow = new AdminWindow();
				adminWindow.Show();
			}
			else if (account != null && txtPassword.Password.Equals(account.Password) && account.Role.Equals("User"))
			{
				UserWindow userWindow = new UserWindow(account.Id);
				userWindow.Show();
			}
			else
			{
				MessageBox.Show("Login failed!");
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}