using System;
using System.Collections.Generic;

namespace ColegioSanJoseWeb.Models;

public partial class Expediente
{
    public int ExpedienteId { get; set; }

    public int AlumnoId { get; set; }

    public int MateriaId { get; set; }

    public decimal? NotaFinal { get; set; }

    public string? Observaciones { get; set; }

    public virtual Alumno? Alumno { get; set; }

    public virtual Materium? Materia { get; set; } 
}
