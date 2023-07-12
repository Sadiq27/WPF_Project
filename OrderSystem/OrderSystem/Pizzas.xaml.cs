using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace OrderSystem
{
    public partial class Pizzas : Window
    {
        public ObservableCollection<BurgerItem> PizzasCollection { get; set; }
        public ObservableCollection<CartItem> CartItems { get; set; }

        public Pizzas()
        {
            InitializeComponent();

            PizzasCollection = new ObservableCollection<BurgerItem>()
            {
                new BurgerItem()
                {
                    ImagePath = "Assets/images/MargheritaPizza.jpg",
                    Title = "Margherita Pizza",
                    Quantity = 0,
                    Price = 6.99m
                },
                new BurgerItem()
                {
                    ImagePath = "Assets/images/PepperoniPizza.png",
                    Title = "Pepperoni Pizza",
                    Quantity = 0,
                    Price = 8.99m
                },
                new BurgerItem()
                {
                    ImagePath = "Assets/images/HawaiianPizza.jpg",
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
            if (sender is FrameworkElement element && element.DataContext is BurgerItem burger)
            {
                burger.Quantity++;
            }
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is BurgerItem burger)
            {
                if (burger.Quantity > 0)
                    burger.Quantity--;
            }
        }

        private void PrevButtonOnOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            Close();
        }

        private void ViewCartButton_Click(object sender, RoutedEventArgs e)
        {
            TotalOrders totalOrders = new TotalOrders();
            totalOrders.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button addButton && addButton.DataContext is BurgerItem selectedBurger)
            {
                if (selectedBurger.Quantity == 0)
                {
                    MessageBox.Show("Quantity should be greater than 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                CartItem cartItem = new CartItem()
                {
                    Title = selectedBurger.Title,
                    Quantity = selectedBurger.Quantity,
                    Price = selectedBurger.Price
                };

                CartItems.Add(cartItem);
                MessageBox.Show("Item added to cart successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
