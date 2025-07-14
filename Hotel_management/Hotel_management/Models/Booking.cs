﻿using System;
using System.Collections.Generic;

namespace HotelManagement.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? GuestId { get; set; }

    public int? RoomId { get; set; }

    public int? UserId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public DateTime? BookingDate { get; set; }

    public string? Status { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual Room? Room { get; set; }

    public virtual User? User { get; set; }
}
