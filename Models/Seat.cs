using System;
using System.Collections.Generic;

namespace cinema_warmup_app.Models;

public partial class Seat
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int IdCinemaHall { get; set; }

    public short CoordX { get; set; }

    public short CoordY { get; set; }

    public virtual CinemaHall CinemaHall { get; set; } = null!;

    public virtual ICollection<Reservation> IdReservations { get; } = new List<Reservation>();
}
