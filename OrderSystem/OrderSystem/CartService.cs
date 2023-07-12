using System.Collections.ObjectModel;
using System.Windows;

namespace OrderSystem
{
    public static class CartService
    {
        public static void AddItemToCart(BurgerItem selectedBurger, ObservableCollection<CartItem> cartItems)
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

            cartItems.Add(cartItem);
            MessageBox.Show("Item added to cart successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
