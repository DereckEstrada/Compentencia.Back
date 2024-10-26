using System;
using System.Collections.Generic;

namespace Competencia.Back.Entities.Entities;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? DescriptionEstado { get; set; }

    public virtual ICollection<ReservaPersona> ReservaPersonas { get; set; } = new List<ReservaPersona>();
}
