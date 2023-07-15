using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using OrderSystem.Classes;

namespace OrderSystem.Views
{
    public partial class Burgers : Window
    {
        public ObservableCollection<OrderItem> BurgersCollection { get; set; }
        public ObservableCollection<CartItem> CartItems { get; set; }

        public Burgers()
        {
            InitializeComponent();

            BurgersCollection = new ObservableCollection<OrderItem>()
            {
                new OrderItem()
                {
                    ImagePath = "../Assets/images/Cheeseburger.jpg",
                    Title = "Cheeseburger",
                    Quantity = 0,
                    Price = 4.99m
                },
                new OrderItem()
                {
                    ImagePath = "../Assets/images/BaconBurger.jpg",
                    Title = "Bacon Burger",
                    Quantity = 0,
                    Price = 5.99m
                },
                new OrderItem()
                {
                    ImagePath = "../Assets/images/MushroomBurger.jpg",
                    Title = "Mushroom Burger",
                    Quantity = 0,
                    Price = 6.99m
                }
            };

            CartItems = CartManager.Instance.CartItems;

            DataContext = this;
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is OrderItem burger)
            {
                BaseMethod.IncrementQuantity(burger);
            }
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is OrderItem burger)
            {
                BaseMethod.DecrementQuantity(burger);
            }
        }

        private void PrevButtonOnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow order = new OrderWindow();
            order.Show();
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button addButton && addButton.DataContext is OrderItem selectedBurger)
            {
                BaseMethod.AddToCart(selectedBurger, CartItems);
            }
        }
    }
}
