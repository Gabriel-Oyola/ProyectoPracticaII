using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPracticaII.Client.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string? NombreUsuario { get; set; }

    [Required(ErrorMessage = "El correo es obligatorio.")]
    public string? Correo { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    public string? Clave { get; set; }

    public virtual ICollection<Motocicleta> Motocicleta { get; set; } = new List<Motocicleta>();

    public virtual ICollection<Opinione> Opiniones { get; set; } = new List<Opinione>();

    public virtual ICollection<Taller> Tallers { get; set; } = new List<Taller>();
}
