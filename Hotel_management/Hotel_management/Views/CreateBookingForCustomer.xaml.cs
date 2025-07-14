using HotelManagement.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class CreateBookingForCustomer : UserControl
    {
        private readonly int currentUserId;

        public CreateBookingForCustomer(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadRooms();
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

        private void CreateBooking_Click(object sender, RoutedEventArgs e)
        {
            int? selectedRoomId = cbRooms.SelectedValue as int?;
            DateTime? checkInDate = dpCheckIn.SelectedDate;
            DateTime? checkOutDate = dpCheckOut.SelectedDate;

            string error = Validator.ValidateNotEmpty("Room", selectedRoomId?.ToString())
                         ?? Validator.ValidateNotEmpty("Check-in Date", checkInDate?.ToString())
                         ?? Validator.ValidateNotEmpty("Check-out Date", checkOutDate?.ToString());

            if (error != null)
            {
                MessageBox.Show(error);
                return;
            }

            DateTime checkIn = checkInDate.Value.Date;
            DateTime checkOut = checkOutDate.Value.Date;
            string dateError = Validator.ValidateDateRange(checkIn, checkOut);
            if (dateError != null)
            {
                MessageBox.Show(dateError);
                return;
            }

            int roomId = selectedRoomId.Value;

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

                var booking = new Booking
                {
                    RoomId = roomId,
                    UserId = currentUserId,
                    CheckInDate = DateOnly.FromDateTime(checkIn),
                    CheckOutDate = DateOnly.FromDateTime(checkOut)
                };

                context.Bookings.Add(booking);
                context.SaveChanges();
                MessageBox.Show("Room booked successfully.");
            }
        }
    }
}
