using System.Windows;
using HotelManagement.ViewModel;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class StaffHome : Window
    {
        public StaffHome()
        {
            InitializeComponent();
        }

        private void CheckRooms_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CheckRoomAvailabilityControl();
        }

        private void CreateBooking_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CreateBookingForStaff();
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
