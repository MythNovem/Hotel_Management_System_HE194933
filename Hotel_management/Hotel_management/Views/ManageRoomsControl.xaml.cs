using HotelManagement.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Views
{
    public partial class ManageRoomsControl : UserControl
    {
        private int editingRoomId = -1;

        public ManageRoomsControl()
        {
            InitializeComponent();
            LoadRooms();
        }

        private void LoadRooms()
        {
            using (var context = new HotelManagementContext())
            {
                dgRooms.ItemsSource = context.Rooms.ToList();
            }
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            string roomNumber = txtRoomNumber.Text.Trim();
            string roomType = txtRoomType.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            string numberError = Validator.ValidateNotEmpty("Room Number", roomNumber);
            string typeError = Validator.ValidateNotEmpty("Room Type", roomType);
            string priceError = Validator.ValidatePrice(priceText);

            if (numberError != null || typeError != null || priceError != null)
            {
                MessageBox.Show(numberError ?? typeError ?? priceError);
                return;
            }

            using (var context = new HotelManagementContext())
            {
                if (context.Rooms.Any(r => r.RoomNumber == roomNumber))
                {
                    MessageBox.Show("Room number already exists.");
                    return;
                }

                var room = new Room
                {
                    RoomNumber = roomNumber,
                    RoomType = roomType,
                    Price = decimal.Parse(priceText)
                };

                context.Rooms.Add(room);
                context.SaveChanges();
            }

            MessageBox.Show("Room added successfully.");
            ClearForm();
            LoadRooms();
        }

        private void EditRoom_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int roomId)
            {
                using (var context = new HotelManagementContext())
                {
                    var room = context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
                    if (room != null)
                    {
                        editingRoomId = room.RoomId;
                        txtRoomNumber.Text = room.RoomNumber;
                        txtRoomType.Text = room.RoomType;
                        txtPrice.Text = room.Price.ToString();
                        btnUpdateRoom.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (editingRoomId == -1) return;

            string roomNumber = txtRoomNumber.Text.Trim();
            string roomType = txtRoomType.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            string numberError = Validator.ValidateNotEmpty("Room Number", roomNumber);
            string typeError = Validator.ValidateNotEmpty("Room Type", roomType);
            string priceError = Validator.ValidatePrice(priceText);

            if (numberError != null || typeError != null || priceError != null)
            {
                MessageBox.Show(numberError ?? typeError ?? priceError);
                return;
            }

            using (var context = new HotelManagementContext())
            {
                var room = context.Rooms.Find(editingRoomId);
                if (room != null)
                {
                    room.RoomNumber = roomNumber;
                    room.RoomType = roomType;
                    room.Price = decimal.Parse(priceText);
                    context.SaveChanges();
                }
            }

            MessageBox.Show("Room updated successfully.");
            ClearForm();
            LoadRooms();
            editingRoomId = -1;
            btnUpdateRoom.Visibility = Visibility.Collapsed;
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int roomId)
            {
                using (var context = new HotelManagementContext())
                {
                    var room = context.Rooms.Find(roomId);
                    if (room != null)
                    {
                        context.Rooms.Remove(room);
                        context.SaveChanges();
                        MessageBox.Show("Room deleted.");
                        LoadRooms();
                    }
                }
            }
        }

        private void ClearForm()
        {
            txtRoomNumber.Text = "";
            txtRoomType.Text = "";
            txtPrice.Text = "";
        }
    }
}
