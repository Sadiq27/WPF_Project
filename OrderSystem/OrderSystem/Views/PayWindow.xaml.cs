using System.ComponentModel;
using System.Windows;

namespace OrderSystem.Views
{
    public partial class PayWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public PayWindow()
        {
            InitializeComponent();
            this.DataContext = this;

        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
            {
            bool check = string.IsNullOrWhiteSpace(CardNumber.Text) || string.IsNullOrWhiteSpace(ExpirationDate.Text) ||
                                string.IsNullOrWhiteSpace(CVV.Text) || string.IsNullOrWhiteSpace(DeliveryAddress.Text);
                if (check)
                    {
                        MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

            MessageBox.Show("Payment successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            ClearCart();
        }

        private void ClearCart()
        {
            TotalOrdersWindow totalOrdersWindow = new TotalOrdersWindow();

            totalOrdersWindow.CartItems.Clear();
            totalOrdersWindow.Close();
            Close();
        }
    }
}
