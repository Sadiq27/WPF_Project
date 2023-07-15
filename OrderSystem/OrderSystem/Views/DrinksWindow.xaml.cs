using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using OrderSystem.Classes;

namespace OrderSystem.Views
{
    public partial class DrinksWindow : Window
    {
        public ObservableCollection<OrderItem> DrinksCollection { get; set; }
        public ObservableCollection<CartItem> CartItems { get; set; }

        public DrinksWindow()
        {
            InitializeComponent();

            DrinksCollection = new ObservableCollection<OrderItem>()
            {
                new OrderItem()
                {
                    ImagePath = "../Assets/images/CocaCola.jpg",
                    Title = "Coca Cola",
                    Quantity = 0,
                    Price = 3.99m
                },
                new OrderItem()
                {
                    ImagePath = "../Assets/images/Fanta.jpg",
                    Title = "Fanta",
                    Quantity = 0,
                    Price = 5.99m
                },
                new OrderItem()
                {
                    ImagePath = "../Assets/images/Sprite.jpg",
                    Title = "Sprite",
                    Quantity = 0,
                    Price = 7.99m
                },
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
