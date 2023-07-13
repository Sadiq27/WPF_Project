using System.Windows;

namespace OrderSystem.Views
{
    public partial class PayWindow : Window
    {
        public PayWindow()
        {
            InitializeComponent();

        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(CardNumber.Text) || string.IsNullOrWhiteSpace(ExpirationDate.Text) ||
                                string.IsNullOrWhiteSpace(CVV.Text) || string.IsNullOrWhiteSpace(DeliveryAddress.Text))
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
            totalOrdersWindow.TotalPrice = 0;
            Close();
        }
    }
}
