using System;
using System.Collections.Generic;

namespace cinema_warmup_app.Models;

public partial class CinemaHall
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<MovieShowing> MovieShowings { get; } = new List<MovieShowing>();

    public virtual ICollection<Seat> Seats { get; } = new List<Seat>();
}
