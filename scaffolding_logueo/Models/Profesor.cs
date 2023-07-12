using System;
using System.Collections.Generic;

namespace scaffolding_logueo.Models;

public partial class Profesor
{
    public int IdProfesor { get; set; }

    public string? Nombres { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Contrasenia { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
