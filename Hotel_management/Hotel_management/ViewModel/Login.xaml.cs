using HotelManagement.Models;
using HotelManagement.Views; // nơi chứa AdminHome, StaffHome, CustomerHome
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace HotelManagement.ViewModel
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();

            // Validate đầu vào
            string error = Validator.ValidateUsername(username)
                         ?? Validator.ValidatePassword(password);

            if (error != null)
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new HotelManagementContext())
                {
                    // Kiểm tra đăng nhập
                    var user = context.Users
                   .Include(u => u.Role)
                   .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

                    if (user != null)
                    {
                        // Lưu thông tin session
                        Session.CurrentUserId = user.UserId;
                        Session.CurrentUserName = user.FullName;
                        Session.CurrentUserRole = user.Role.RoleName;

                        MessageBox.Show($"Welcome {user.FullName}! Role: {user.Role.RoleName}", "Login Successful");

                        Window home = user.Role.RoleName.ToLower() switch
                        {
                            "admin" => new AdminHome(),
                            "staff" => new StaffHome(),
                            "customer" => new CustomerHome(),
                            _ => throw new Exception("Unknown role.")
                        };

                        home.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred:\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
