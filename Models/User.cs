using System;
using System.Collections.Generic;

namespace cinema_warmup_app.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
