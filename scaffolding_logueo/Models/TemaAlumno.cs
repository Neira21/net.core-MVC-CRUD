using System;
using System.Collections.Generic;

namespace scaffolding_logueo.Models;

public partial class TemaAlumno
{
    public int IdTema { get; set; }

    public int IdAlumno { get; set; }

    public int? Nota { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Tema IdTemaNavigation { get; set; } = null!;
}
