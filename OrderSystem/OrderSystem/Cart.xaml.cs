using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrderSystem
{
    public partial class Cart : Window
    {
        public ObservableCollection<CartItem> CartItems { get; set; }

        public Cart(ObservableCollection<CartItem> cartItems)
        {
            InitializeComponent();

            CartItems = cartItems;

            DataContext = this;
        }
    }
}
