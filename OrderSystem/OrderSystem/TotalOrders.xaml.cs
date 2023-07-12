using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace OrderSystem
{
    public partial class TotalOrders : Window
    {
        public ObservableCollection<CartItem> CartItems { get; set; }

        public TotalOrders()
        {
            InitializeComponent();
            CartItems = CartManager.Instance.CartItems;
            DataContext = this;
        }

        private void PrevButtonOnTotalOrders_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            Close();
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
