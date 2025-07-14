using HotelManagement.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class CheckRoomAvailabilityControl : UserControl
    {
        public CheckRoomAvailabilityControl()
        {
            InitializeComponent();
        }

        private void CheckAvailability_Click(object sender, RoutedEventArgs e)
        {
            if (dpCheckIn.SelectedDate == null || dpCheckOut.SelectedDate == null)
            {
                MessageBox.Show("Please select both check-in and check-out dates.");
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

            using (var context = new HotelManagementContext())
            {
                var availableRooms = context.Rooms.Where(room =>
                    !context.Bookings.Any(b =>
                        b.RoomId == room.RoomId &&
                        (
                            (DateOnly.FromDateTime(checkIn) >= b.CheckInDate && DateOnly.FromDateTime(checkIn) < b.CheckOutDate) ||
                            (DateOnly.FromDateTime(checkOut) > b.CheckInDate && DateOnly.FromDateTime(checkOut) <= b.CheckOutDate) ||
                            (DateOnly.FromDateTime(checkIn) < b.CheckInDate && DateOnly.FromDateTime(checkOut) > b.CheckOutDate)
                        )
                    )).ToList();

                dgAvailableRooms.ItemsSource = availableRooms;
            }
        }
    }
}
