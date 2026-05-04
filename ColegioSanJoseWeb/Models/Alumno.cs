using System;
using System.Collections.Generic;

namespace ColegioSanJoseWeb.Models;

public partial class Alumno
{
    public int AlumnoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Grado { get; set; } = null!;

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
