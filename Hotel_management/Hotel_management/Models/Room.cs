using System;
using System.Collections.Generic;

namespace HotelManagement.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string? RoomType { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
