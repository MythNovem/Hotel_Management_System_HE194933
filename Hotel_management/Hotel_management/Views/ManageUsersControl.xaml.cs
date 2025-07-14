using HotelManagement.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using HotelManagement; // Validator namespace

namespace HotelManagement.Views
{
    public partial class ManageUsersControl : UserControl
    {
        private int editingUserId = -1;

        public ManageUsersControl()
        {
            InitializeComponent();
            LoadRoles();
            LoadUsers();
        }

        private void LoadRoles()
        {
            using (var context = new HotelManagementContext())
            {
                cbRole.ItemsSource = context.Roles.ToList();
                cbRole.DisplayMemberPath = "RoleName";
                cbRole.SelectedValuePath = "RoleId";
            }
        }

        private void LoadUsers()
        {
            using (var context = new HotelManagementContext())
            {
                dgUsers.ItemsSource = context.Users.Include(u => u.Role).ToList();
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();
            var selectedRoleId = cbRole.SelectedValue;

            var usernameError = Validator.ValidateUsername(username);
            var passwordError = Validator.ValidatePassword(password);
            if (usernameError != null || passwordError != null || selectedRoleId == null)
            {
                MessageBox.Show(usernameError ?? passwordError ?? "Please select a role.");
                return;
            }

            using (var context = new HotelManagementContext())
            {
                if (context.Users.Any(u => u.Username == username))
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }

                var user = new User
                {
                    Username = username,
                    PasswordHash = password,
                    RoleId = (int)selectedRoleId
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            MessageBox.Show("User added successfully.");
            ClearForm();
            LoadUsers();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int userId)
            {
                using (var context = new HotelManagementContext())
                {
                    var user = context.Users.Find(userId);
                    if (user != null)
                    {
                        editingUserId = userId;
                        txtUsername.Text = user.Username;
                        txtPassword.Password = user.PasswordHash;
                        cbRole.SelectedValue = user.RoleId;

                        btnUpdate.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (editingUserId == -1)
                return;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();
            var selectedRoleId = cbRole.SelectedValue;

            var usernameError = Validator.ValidateUsername(username);
            var passwordError = Validator.ValidatePassword(password);
            if (usernameError != null || passwordError != null || selectedRoleId == null)
            {
                MessageBox.Show(usernameError ?? passwordError ?? "Please select a role.");
                return;
            }

            using (var context = new HotelManagementContext())
            {
                var user = context.Users.Find(editingUserId);
                if (user != null)
                {
                    user.Username = username;
                    user.PasswordHash = password;
                    user.RoleId = (int)selectedRoleId;
                    context.SaveChanges();
                }
            }

            MessageBox.Show("User updated successfully.");
            ClearForm();
            LoadUsers();
            btnUpdate.Visibility = Visibility.Collapsed;
            editingUserId = -1;
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int userId)
            {
                using (var context = new HotelManagementContext())
                {
                    var user = context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserId == userId);
                    if (user != null)
                    {
                        var validationMessage = Validator.ValidateDeletableUser(user.Role.RoleName);
                        if (validationMessage != null)
                        {
                            MessageBox.Show(validationMessage);
                            return;
                        }

                        context.Users.Remove(user);
                        context.SaveChanges();
                        MessageBox.Show("User deleted.");
                        LoadUsers();
                    }
                }
            }
        }

        private void ClearForm()
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
            cbRole.SelectedIndex = -1;
        }
    }
}