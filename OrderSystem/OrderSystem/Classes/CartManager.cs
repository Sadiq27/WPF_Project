using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Classes
{
    public class CartManager
    {
        private static readonly CartManager instance = new CartManager();

        public static CartManager Instance
        {
            get { return instance; }
        }

        public ObservableCollection<CartItem> CartItems { get; private set; }

        private CartManager()
        {
            CartItems = new ObservableCollection<CartItem>();
        }
    }

}
