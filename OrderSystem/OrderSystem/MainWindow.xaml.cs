using System;
using System.IO;
using System.Text.Json;
using System.Windows;


namespace OrderSystem
{
    public partial class MainWindow : Window
    {
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
            File.WriteAllText("users.json", jsonString);

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
                string jsonString = File.ReadAllText("users.json");
                User? storedUser = JsonSerializer.Deserialize<User>(jsonString);

                if (storedUser != null && storedUser.Username == username && storedUser.Password == password)
                {
                    MessageBox.Show("Login successful", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    Dashboard dashboard = new Dashboard();
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

