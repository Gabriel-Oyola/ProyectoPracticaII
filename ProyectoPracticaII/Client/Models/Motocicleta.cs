using System;
using System.Collections.Generic;

namespace ProyectoPracticaII.Client.Models;

public partial class Motocicleta
{
    public int IdMoto { get; set; }

    public int? IdUsuario { get; set; }

    public string? Patente { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Año { get; set; }

    public string? Aseguradora { get; set; }

    public string? Estado { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
