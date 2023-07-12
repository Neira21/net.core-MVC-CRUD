using System;
using System.Collections.Generic;

namespace scaffolding_logueo.Models;

public partial class Anio
{
    public int IdAnio { get; set; }

    public int? Anio1 { get; set; }

    public virtual ICollection<Bimestre> Bimestres { get; set; } = new List<Bimestre>();

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();
}
