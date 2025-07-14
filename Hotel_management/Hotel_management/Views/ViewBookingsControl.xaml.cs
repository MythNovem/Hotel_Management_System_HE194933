using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class ViewBookingsControl : UserControl
    {
        public ViewBookingsControl()
        {
            InitializeComponent();
            LoadBookings();
        }

        private void LoadBookings()
        {
            using (var context = new HotelManagementContext())
            {
                var bookings = context.Bookings
                    .Include(b => b.User)
                    .Include(b => b.Room)
                    .Select(b => new
                    {
                        b.BookingId,
                        b.Room.RoomNumber,
                        b.User.FullName,
                        b.CheckInDate,
                        b.CheckOutDate
                    })
                    .ToList();

                dgBookings.ItemsSource = bookings;
            }
        }
    }
}
