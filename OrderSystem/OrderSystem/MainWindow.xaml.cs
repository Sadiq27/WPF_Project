using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using OrderSystem.Classes;

namespace OrderSystem
{
    public partial class MainWindow : Window
    {
        string filePath = "Assets/Data/users.json";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User user = new User
            {
                Username = username,
                Password = password
            };

            string jsonString = JsonSerializer.Serialize(user);
            File.WriteAllText(filePath, jsonString);

            MessageBox.Show("User registered successfully", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);
                User? storedUser = JsonSerializer.Deserialize<User>(jsonString);

                if (storedUser != null && storedUser.Username == username && storedUser.Password == password)
                {
                    MessageBox.Show("Login successful", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    Views.DashboardWindow dashboard = new Views.DashboardWindow();
                    dashboard.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred during login. Please contact support for assistance", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

