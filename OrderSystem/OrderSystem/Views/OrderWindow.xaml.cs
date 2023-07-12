using System.Windows;
using System.Windows.Controls;
using OrderSystem.Classes;

namespace OrderSystem.Views
{
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboard = new DashboardWindow();
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
                        burgers.Show(); Close();

                        break;
                    case "Pizzas":
                        Pizzas pizzas = new Pizzas();
                        pizzas.Show(); Close();

                        break;
                    case "Sushi":
                        SushiWindow sushi = new SushiWindow();
                        sushi.Show(); Close();

                        break;
                    case "Drinks":
                        DrinksWindow drinksWindow = new DrinksWindow();
                        drinksWindow.Show(); Close();

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
