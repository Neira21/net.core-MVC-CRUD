using System;
using System.Collections.Generic;

namespace scaffolding_logueo.Models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public int? Grado { get; set; }

    public string? Seccion { get; set; }

    public int? IdAnio { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();

    public virtual Anio? IdAnioNavigation { get; set; }

    public virtual ICollection<Alumno> IdAlumnos { get; set; } = new List<Alumno>();
}
