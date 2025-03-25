using System;
using System.Collections.Generic;

namespace ReservaTours.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool EsAdmin { get; set; }

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
