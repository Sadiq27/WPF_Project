﻿using System;
using System.Collections.Generic;
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
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            Close();
        }

        private void HistoryOrder_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TotalOrders_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}