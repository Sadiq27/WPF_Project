using System.Collections.ObjectModel;
using System.Windows;
using OrderSystem.Classes;
using OrderSystem.Views;

namespace OrderSystem.Views
{
    public partial class DashboardWindow : Window
    {
        public ObservableCollection<CartItem> CartItems { get; set; }

        public DashboardWindow()
        {
            InitializeComponent();
            CartItems = CartManager.Instance.CartItems;
            DataContext = this;
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow order = new OrderWindow();
            order.Show();
            Close();
        }

        private void HistoryOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TotalOrders_Click(object sender, RoutedEventArgs e)
        {
            TotalOrdersWindow totalOrders = new TotalOrdersWindow();
            totalOrders.Show();
            Close();
        }
    }

}
