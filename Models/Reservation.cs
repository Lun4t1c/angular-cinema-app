using System;
using System.Collections.Generic;

namespace cinema_warmup_app.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdMovieShowing { get; set; }

    //public virtual MovieShowing MovieShowing { get; set; } = null!;

    //public virtual User User { get; set; } = null!;

    //public virtual ICollection<Seat> Seats { get; } = new List<Seat>();
    public virtual ICollection<int> SeatsId { get; } = new List<int>();
}
