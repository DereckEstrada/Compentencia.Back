using System;
using System.Collections.Generic;

namespace Competencia.Back.Entities.Entities;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string? NombrePersona { get; set; }

    public string? ApellidoPersona { get; set; }

    public string? CedulaPersona { get; set; }

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<ReservaPersona> ReservaPersonas { get; set; } = new List<ReservaPersona>();
}
