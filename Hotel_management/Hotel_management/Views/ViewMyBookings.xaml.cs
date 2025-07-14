using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class ViewMyBookings : UserControl
    {
        private readonly int currentUserId;

        public ViewMyBookings(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadBookings();
        }

        private void LoadBookings()
        {
            using (var context = new HotelManagementContext())
            {
                var bookings = context.Bookings
                                      .Include(b => b.Room)
                                      .Where(b => b.UserId == currentUserId)
                                      .Select(b => new
                                      {
                                          b.BookingId,
                                          RoomNumber = b.Room.RoomNumber,
                                          RoomType = b.Room.RoomType,
                                          CheckInDate = b.CheckInDate.ToString("yyyy-MM-dd"),
                                          CheckOutDate = b.CheckOutDate.ToString("yyyy-MM-dd")
                                      })
                                      .ToList();

                dgMyBookings.ItemsSource = bookings;
            }
        }
    }
}