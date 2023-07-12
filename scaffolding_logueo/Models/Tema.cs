using System;
using System.Collections.Generic;

namespace scaffolding_logueo.Models;

public partial class Tema
{
    public int IdTema { get; set; }

    public int? IdBimestre { get; set; }

    public int? IdAsignatura { get; set; }

    public string? NombreTema { get; set; }

    public string? Descripcion { get; set; }

    public virtual Asignatura? IdAsignaturaNavigation { get; set; }

    public virtual Bimestre? IdBimestreNavigation { get; set; }

    public virtual ICollection<TemaAlumno> TemaAlumnos { get; set; } = new List<TemaAlumno>();
}
