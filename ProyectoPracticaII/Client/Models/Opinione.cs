using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPracticaII.Client.Models;

public partial class Opinione
{
    public int? IdUsuario { get; set; }

    public int? IdTaller { get; set; }

    public int IdOpinion { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio completarlo.")]
    public string? Comentario { get; set; }

    public string? Fecha { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio completarlo.")]
    public int? Rating { get; set; }

    public virtual Taller? IdTallerNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<ReportesOpinione> ReportesOpiniones { get; set; } = new List<ReportesOpinione>();
}
