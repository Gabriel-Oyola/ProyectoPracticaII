using System;
using System.Collections.Generic;

namespace ProyectoPracticaII.Client.Models;

public partial class Taller
{
    public int IdTaller { get; set; }

    public int? IdUsuario { get; set; }

    public string? NombreTaller { get; set; }

    public string? País { get; set; }

    public string? Provincia { get; set; }

    public string? Localidad { get; set; }

    public string? Direccion { get; set; }

    public string? Email { get; set; }

    public string? Numero { get; set; }

    public string? Horarios { get; set; }

    public string? LinksMapa { get; set; }

    public string? Estado { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Opinione> Opiniones { get; set; } = new List<Opinione>();
}
