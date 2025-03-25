using System;
using System.Collections.Generic;

namespace ReservaTours.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int TourId { get; set; }

    public DateTime? FechaReserva { get; set; }

    public virtual Tour Tour { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
