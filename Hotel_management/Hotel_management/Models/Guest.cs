using System;
using System.Collections.Generic;

namespace HotelManagement.Models;

public partial class Guest
{
    public int GuestId { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
