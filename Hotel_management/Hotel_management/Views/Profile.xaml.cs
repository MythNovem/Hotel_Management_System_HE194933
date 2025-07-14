using HotelManagement.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class Profile : UserControl
    {
        private readonly int currentUserId;

        public Profile(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadProfile();
        }

        private void LoadProfile()
        {
            using (var context = new HotelManagementContext())
            {
                var user = context.Users
                                  .Where(u => u.UserId == currentUserId)
                                  .Select(u => new
                                  {
                                      u.Username,
                                      u.FullName,
                                      u.PasswordHash,
                                      u.Role.RoleName
                                  })
                                  .FirstOrDefault();

                if (user != null)
                {
                    txtUsername.Text = user.Username;
                    txtFullName.Text = user.FullName;
                    txtPassword.Password = user.PasswordHash;
                    txtRole.Text = user.RoleName;
                }
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Password.Trim();

            string error = Validator.ValidateNotEmpty("Full Name", fullName)
                         ?? Validator.ValidatePassword(password);

            if (error != null)  
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new HotelManagementContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == currentUserId);
                if (user != null)
                {
                    user.FullName = fullName;
                    user.PasswordHash = password;
                    context.SaveChanges();
                    MessageBox.Show("Profile updated successfully.");
                }
            }
        }
    }
}
