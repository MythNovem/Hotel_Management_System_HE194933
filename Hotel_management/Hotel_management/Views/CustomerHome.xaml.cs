using System.Windows;
using HotelManagement.ViewModel;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class CustomerHome : Window
    {
        public CustomerHome()
        {
            InitializeComponent();
        }

        private void BookRoom_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CreateBookingForCustomer(Session.CurrentUserId);
        }

        private void MyBookings_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ViewMyBookings(Session.CurrentUserId);
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
