using OrderSystem.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace OrderSystem.Classes
{
    public class BaseMethod
    {
        public static void IncrementQuantity(OrderItem item)
        {
            item.Quantity++;
        }

        public static void DecrementQuantity(OrderItem item)
        {
            if (item.Quantity > 0)
                item.Quantity--;
        }

        public static void AddToCart(OrderItem selectedItem, ObservableCollection<CartItem> cartItems)
        {
            if (selectedItem.Quantity == 0)
            {
                MessageBox.Show("Quantity should be greater than 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CartItem cartItem = new CartItem()
            {
                Title = selectedItem.Title,
                Quantity = selectedItem.Quantity,
                Price = selectedItem.Price,
            };

            cartItems.Add(cartItem);
            MessageBox.Show("Item added to cart successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}
