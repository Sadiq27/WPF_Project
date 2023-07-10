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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void NextButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            Close();
        }



    }
}
