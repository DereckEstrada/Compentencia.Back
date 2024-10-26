using System;
using System.Collections.Generic;

namespace Competencia.Back.Entities.Entities;

public partial class Oficina
{
    public int IdOficina { get; set; }

    public string? NombreOficina { get; set; }

    public virtual ICollection<ReservaPersona> ReservaPersonas { get; set; } = new List<ReservaPersona>();
}
