using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using OrderSystem.Classes;

namespace OrderSystem.Views
{
    public partial class Pizzas : Window
    {
        public ObservableCollection<OrderItem> PizzasCollection { get; set; }
        public ObservableCollection<CartItem> CartItems { get; set; }

        public Pizzas()
        {
            InitializeComponent();

            PizzasCollection = new ObservableCollection<OrderItem>()
            {
                new OrderItem()
                {
                    ImagePath = "../Assets/images/MargheritaPizza.jpg",
                    Title = "Margherita Pizza",
                    Quantity = 0,
                    Price = 6.99m
                },
                new OrderItem()
                {
                    ImagePath = "../Assets/images/PepperoniPizza.png",
                    Title = "Pepperoni Pizza",
                    Quantity = 0,
                    Price = 8.99m
                },
                new OrderItem()
                {
                    ImagePath = "../Assets/images/HawaiianPizza.jpg",
                    Title = "Hawaiian Pizza",
                    Quantity = 0,
                    Price = 7.99m
                }
            };

            CartItems = CartManager.Instance.CartItems;

            DataContext = this;
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is OrderItem Pizza)
            {
                Pizza.Quantity++;
            }
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is OrderItem Pizza)
            {
                if (Pizza.Quantity > 0)
                    Pizza.Quantity--;
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
            if (sender is Button addButton && addButton.DataContext is OrderItem selectedPizza)
            {
                if (selectedPizza.Quantity == 0)
                {
                    MessageBox.Show("Quantity should be greater than 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                CartItem cartItem = new CartItem()
                {
                    Title = selectedPizza.Title,
                    Quantity = selectedPizza.Quantity,
                    Price = selectedPizza.Price
                };

                CartItems.Add(cartItem);
                MessageBox.Show("Item added to cart successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
