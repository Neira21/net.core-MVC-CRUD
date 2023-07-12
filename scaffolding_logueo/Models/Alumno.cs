using System;
using System.Collections.Generic;

namespace scaffolding_logueo.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string? Nombres { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Email { get; set; }

    public string? Genero { get; set; }

    public virtual ICollection<TemaAlumno> TemaAlumnos { get; set; } = new List<TemaAlumno>();

    public virtual ICollection<Grupo> IdGrupos { get; set; } = new List<Grupo>();
}
