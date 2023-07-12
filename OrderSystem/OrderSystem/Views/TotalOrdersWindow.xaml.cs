using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using OrderSystem.Classes;

namespace OrderSystem.Views
{
    public partial class TotalOrdersWindow : Window
    {
        public ObservableCollection<CartItem> CartItems { get; set; }

        public TotalOrdersWindow()
        {
            InitializeComponent();
            CartItems = CartManager.Instance.CartItems;
            DataContext = this;
        }

        private void PrevButtonOnTotalOrders_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboard = new DashboardWindow();
            dashboard.Show();
            Close();
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
