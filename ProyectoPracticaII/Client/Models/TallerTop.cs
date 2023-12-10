using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPracticaII.Client.Models;

public partial class TallerTop
{
    [Key]
    public int IdTop { get; set; } 
    public int IdTaller { get; set; }
    public string NombreTaller { get; set; }
    public double PromedioRating { get; set; }

    public virtual Taller? IdTallerNavigation { get; set; }
}
