using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPracticaII.Client.Models;

public partial class ReportesOpinione
{
    public int? IdUsuarioRc { get; set; }

    public int? IdTaller { get; set; }

    public int? IdOpinion { get; set; }

    public int IdReporte { get; set; }

    public string? Comentario { get; set; }

    public string? Fecha { get; set; }

    public int? Rating { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio completarlo.")]
    public string? Motivo { get; set; }

    public virtual Opinione? IdOpinionNavigation { get; set; }
}
