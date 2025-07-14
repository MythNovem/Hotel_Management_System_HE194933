using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class AdminReports : UserControl
    {
        public AdminReports()
        {
            InitializeComponent();
        }

        private void ViewAllBookings_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HotelManagementContext())
            {
                var bookings = context.Bookings
                    .Include(b => b.Room)
                    .Include(b => b.Guest)
                    .Select(b => new
                    {
                        Room = b.Room.RoomNumber,
                        Guest = b.Guest.FullName,
                        b.CheckInDate,
                        b.CheckOutDate,
                        b.BookingDate
                    })
                    .ToList();

                dgReport.ItemsSource = bookings;
            }
        }

        private void RoomUsageStats_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HotelManagementContext())
            {
                var usage = context.Bookings
                    .GroupBy(b => b.Room.RoomNumber)
                    .Select(g => new
                    {
                        Room = g.Key,
                        TimesBooked = g.Count()
                    })
                    .ToList();

                dgReport.ItemsSource = usage;
            }
        }

        private void RevenueReport_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HotelManagementContext())
            {
                var revenue = context.Bookings
                    .Include(b => b.Room)
                    .Select(b => new
                    {
                        b.BookingDate,
                        b.Room.Price
                    })
                    .ToList();

                var total = revenue.Sum(r => r.Price);
                dgReport.ItemsSource = revenue;
                MessageBox.Show($"Total Revenue: {total:C}");
            }
        }
    }
}
