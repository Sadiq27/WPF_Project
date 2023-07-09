using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


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

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                User user = new User
                {
                    Username = username,
                    Password = password
                };

                string jsonString = JsonSerializer.Serialize(user);
                File.WriteAllText("users.json", jsonString);

                MessageBox.Show("User registered successfully");
            }
            else
            {
                MessageBox.Show("Please enter a username and password");
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    string jsonString = File.ReadAllText("users.json");
                    User? storedUser = JsonSerializer.Deserialize<User>(jsonString);

                    if (storedUser != null && storedUser.Username == username && storedUser.Password == password)
                    {
                        MessageBox.Show("Login successful");
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                        Close();
                    }
                    else
                    {

                        MessageBox.Show("Invalid username or password");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occurred during login. Please contact support for assistance");
                }
            }   
            else
            {
                MessageBox.Show("Please enter a username and password");
            }
        }
    }
}

