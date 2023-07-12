using System;
using System.Collections.Generic;

namespace scaffolding_logueo.Models;

public partial class Bimestre
{
    public int IdBimestre { get; set; }

    public string? NombreBimestre { get; set; }

    public int? IdAnio { get; set; }

    public virtual Anio? IdAnioNavigation { get; set; }

    public virtual ICollection<Tema> Temas { get; set; } = new List<Tema>();
}
