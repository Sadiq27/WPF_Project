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
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is BlockItem blockItem)
            {
                string imagePath = blockItem.ImagePath;
                string title = blockItem.Title;

                switch (title)
                {
                    case "Burgers":
                        Burgers burgers = new Burgers();
                        burgers.Show();
                        Close();

                        break;
                    case "Pizzas":
                        Pizzas pizzas = new Pizzas();
                        pizzas.Show(); 
                        Close();
                        break;
                    case "Sushi":

                        break;
                    case "Drinks":

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
