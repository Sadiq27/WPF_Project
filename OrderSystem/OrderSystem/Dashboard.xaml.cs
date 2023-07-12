using System.Collections.ObjectModel;
using System.Windows;

namespace OrderSystem
{
    public partial class Dashboard : Window
    {
        public ObservableCollection<CartItem> CartItems { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            CartItems = CartManager.Instance.CartItems;
            DataContext = this;
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            Close();
        }

        private void HistoryOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TotalOrders_Click(object sender, RoutedEventArgs e)
        {
            TotalOrders totalOrders = new TotalOrders();
            totalOrders.Show();
            Close();
        }
    }

}
