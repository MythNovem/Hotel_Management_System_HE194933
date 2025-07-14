using System.Windows;
using HotelManagement.ViewModel;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class AdminHome : Window
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ManageUsersControl();
        }

        private void ManageRooms_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ManageRoomsControl();
        }

        private void ViewBookings_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ViewBookingsControl();
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AdminReports();
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Profile(Session.CurrentUserId);
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Close();
        }

       
    }
}
