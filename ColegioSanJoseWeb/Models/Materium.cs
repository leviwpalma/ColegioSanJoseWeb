using System;
using System.Collections.Generic;

namespace ColegioSanJoseWeb.Models;

public partial class Materium
{
    public int MateriaId { get; set; }

    public string NombreMateria { get; set; } = null!;

    public string Docente { get; set; } = null!;

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
