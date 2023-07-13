using System.Collections.ObjectModel;

namespace OrderSystem.Classes
{
    public class CartManager
    {
        public ObservableCollection<CartItem> CartItems { get; private set; }
        private static readonly CartManager instance = new CartManager();

        public static CartManager Instance
        {
            get { return instance; }
        }

        private CartManager()
        {
            CartItems = new ObservableCollection<CartItem>();
        }
    }

}
