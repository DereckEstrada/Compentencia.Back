using System;
using System.Collections.Generic;

namespace Competencia.Back.Entities.Entities;

public partial class ReservaPersona
{
    public int IdReservaPersona { get; set; }

    public int? IdPersona { get; set; }

    public int? IdOficina { get; set; }

    public DateTime? DateReserva { get; set; }

    public int? IdEstado { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Oficina? IdOficinaNavigation { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
