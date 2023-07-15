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
            bool CardNumberCheck = string.IsNullOrWhiteSpace(CardNumber.Text);
            bool ExpirationDateCheck = string.IsNullOrWhiteSpace(ExpirationDate.Text);
            bool CVVCheck = string.IsNullOrWhiteSpace(CVV.Text);
            bool DeliveryAddressCheck = string.IsNullOrWhiteSpace(DeliveryAddress.Text);

            if (CardNumberCheck || ExpirationDateCheck || CVVCheck || DeliveryAddressCheck)
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
