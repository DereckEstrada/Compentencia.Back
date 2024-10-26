using System;
using System.Collections.Generic;

namespace Competencia.Back.Entities.Entities;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? DescriptionRol { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
