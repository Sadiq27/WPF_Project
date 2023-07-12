using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using OrderSystem.Classes;

namespace OrderSystem.Views
{
    public partial class SushiWindow : Window
    {
        public ObservableCollection<OrderItem> SushiCollection { get; set; }
        public ObservableCollection<CartItem> CartItems { get; set; }

        public SushiWindow()
        {
            InitializeComponent();

            SushiCollection = new ObservableCollection<OrderItem>()
            {
                new OrderItem()
                {
                    ImagePath = "../Assets/images/TunaRoll.png",
                    Title = "Tuna Roll",
                    Quantity = 0,
                    Price = 3.99m
                },
                new OrderItem()
                {
                    ImagePath = "../Assets/images/SalmonNigiri.jpg",
                    Title = "Salmon Nigiri",
                    Quantity = 0,
                    Price = 5.99m
                },
                new OrderItem()
                {
                    ImagePath = "../Assets/images/CaliforniaRoll.jpg",
                    Title = "California Roll",
                    Quantity = 0,
                    Price = 7.99m
                }
            };

            CartItems = CartManager.Instance.CartItems;

            DataContext = this;
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is OrderItem Sushi)
            {
                Sushi.Quantity++;
            }
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is OrderItem Sushi)
            {
                if (Sushi.Quantity > 0)
                    Sushi.Quantity--;
            }
        }

        private void PrevButtonOnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow order = new OrderWindow();
            order.Show();
            Close();
        }

        private void ViewCartButton_Click(object sender, RoutedEventArgs e)
        {
            TotalOrdersWindow totalOrders = new TotalOrdersWindow();
            totalOrders.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button addButton && addButton.DataContext is OrderItem selectedSushi)
            {
                if (selectedSushi.Quantity == 0)
                {
                    MessageBox.Show("Quantity should be greater than 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                CartItem cartItem = new CartItem()
                {
                    Title = selectedSushi.Title,
                    Quantity = selectedSushi.Quantity,
                    Price = selectedSushi.Price
                };

                CartItems.Add(cartItem);
                MessageBox.Show("Item added to cart successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
