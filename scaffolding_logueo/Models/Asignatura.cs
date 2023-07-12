using System;
using System.Collections.Generic;

namespace scaffolding_logueo.Models;

public partial class Asignatura
{
    public int IdAsignatura { get; set; }

    public string? NombreAsignatura { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();

    public virtual ICollection<Tema> Temas { get; set; } = new List<Tema>();
}
