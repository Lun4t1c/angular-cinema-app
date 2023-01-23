using System;
using System.Collections.Generic;

namespace cinema_warmup_app.Models;

public partial class MovieShowing
{
    public int Id { get; set; }

    public DateTime BeginDate { get; set; }

    public int IdMovie { get; set; }

    public int IdCinemaHall { get; set; }

    public virtual CinemaHall CinemaHall { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
