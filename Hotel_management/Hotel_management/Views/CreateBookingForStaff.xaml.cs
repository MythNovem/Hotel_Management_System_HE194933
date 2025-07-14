using HotelManagement.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class CreateBookingForStaff : UserControl
    {
        public CreateBookingForStaff()
        {
            InitializeComponent();
            LoadRooms();
            LoadCustomers();
        }

        private void LoadRooms()
        {
            using (var context = new HotelManagementContext())
            {
                cbRooms.ItemsSource = context.Rooms.ToList();
                cbRooms.DisplayMemberPath = "RoomNumber";
                cbRooms.SelectedValuePath = "RoomId";
            }
        }

        private void LoadCustomers()
        {
            using (var context = new HotelManagementContext())
            {
                cbCustomers.ItemsSource = context.Users
                    .Where(u => u.Role != null && u.Role.RoleName != null && u.Role.RoleName.ToLower() == "customer")
                    .ToList();

                cbCustomers.DisplayMemberPath = "Username";
                cbCustomers.SelectedValuePath = "UserId";
            }
        }

        private void CreateBooking_Click(object sender, RoutedEventArgs e)
        {
            if (cbRooms.SelectedValue == null || cbCustomers.SelectedValue == null ||
                dpCheckIn.SelectedDate == null || dpCheckOut.SelectedDate == null)
            {
                MessageBox.Show("Please select room, customer, and both dates.");
                return;
            }

            DateTime checkIn = dpCheckIn.SelectedDate.Value.Date;
            DateTime checkOut = dpCheckOut.SelectedDate.Value.Date;
            string dateError = Validator.ValidateDateRange(checkIn, checkOut);
            if (dateError != null)
            {
                MessageBox.Show(dateError);
                return;
            }

            int roomId = (int)cbRooms.SelectedValue;
            int userId = (int)cbCustomers.SelectedValue;

            using (var context = new HotelManagementContext())
            {
                bool conflict = context.Bookings.Any(b =>
                    b.RoomId == roomId &&
                    ((DateOnly.FromDateTime(checkIn) >= b.CheckInDate && DateOnly.FromDateTime(checkIn) < b.CheckOutDate) ||
                     (DateOnly.FromDateTime(checkOut) > b.CheckInDate && DateOnly.FromDateTime(checkOut) <= b.CheckOutDate) ||
                     (DateOnly.FromDateTime(checkIn) < b.CheckInDate && DateOnly.FromDateTime(checkOut) > b.CheckOutDate)));

                if (conflict)
                {
                    MessageBox.Show("Selected room is already booked in this date range.");
                    return;
                }

                var booking = GetBooking(checkIn, checkOut, roomId, userId);

                context.Bookings.Add(booking);
                context.SaveChanges();
                MessageBox.Show("Booking created successfully.");
            }
        }

        private static Booking GetBooking(DateTime checkIn, DateTime checkOut, int roomId, int userId)
        {
            return new Booking
            {
                RoomId = roomId,
                UserId = userId,
                CheckInDate = DateOnly.FromDateTime(checkIn),
                CheckOutDate = DateOnly.FromDateTime(checkOut)
            };
        }
    }
}
