using System;
using System.Collections.Generic;

namespace scaffolding_logueo.Models;

public partial class Clase
{
    public int IdAsignatura { get; set; }

    public int IdGrupo { get; set; }

    public int IdProfesor { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    public virtual Grupo IdGrupoNavigation { get; set; } = null!;

    public virtual Profesor IdProfesorNavigation { get; set; } = null!;
}
