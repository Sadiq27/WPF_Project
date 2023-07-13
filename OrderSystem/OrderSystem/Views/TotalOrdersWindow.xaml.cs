using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Linq;
using OrderSystem.Classes;
using System;

namespace OrderSystem.Views
{
    public partial class TotalOrdersWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<CartItem> CartItems { get; set; }

        public decimal totalPrice = 0;

        public TotalOrdersWindow()
        {
            InitializeComponent();
            CartItems = CartManager.Instance.CartItems;
            DataContext = this;

            CalculateTotalPrice();
        }

        public decimal TotalPrice
        {
            get { return totalPrice; }
            set
            {
                if (totalPrice != value)
                {
                    totalPrice = value;
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = CartItems.Sum(item => item.Total);
        }


        private void PrevButtonOnTotalOrders_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboard = new DashboardWindow();
            dashboard.Show();
            Close();
        }

        private void PayWindow_Closed(object sender, EventArgs e)
        {
            if (CartItems == null || CartItems.Count == 0)
            {
                TotalPrice = 0;
            }
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            if (CartItems == null || CartItems.Count == 0)
            {
                MessageBox.Show("No orders, please order!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                PayWindow payWindow = new PayWindow();
                payWindow.Closed += PayWindow_Closed;
                payWindow.Show();
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
