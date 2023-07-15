using OrderSystem.Classes;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;

namespace OrderSystem.Views
{
    public partial class HistoryOrderWindow : Window
    {
        public ObservableCollection<CartItem> OrderHistory { get; set; }

        public HistoryOrderWindow()
        {
            InitializeComponent();
            OrderHistory = new ObservableCollection<CartItem>();
            DataContext = this;
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            if (File.Exists("history.json"))
            {
                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<CartItem>));

                using (var fileStream = new FileStream("history.json", FileMode.Open))
                {
                    OrderHistory = (ObservableCollection<CartItem>)serializer.ReadObject(fileStream);
                }
            }
        }

        private void PrevButtonOnOrder_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            Close();
        }
    }
}
