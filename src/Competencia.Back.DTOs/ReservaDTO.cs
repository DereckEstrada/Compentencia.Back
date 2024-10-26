using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Back.DTOs
{
    public class ReservaDTO
    {
        public int? IdReservaPersona { get; set; }
        public int? IdPersona { get; set; }
        public string? cedulaPersona { get; set; }
        public int? IdOficina { get; set; }
        public string? nombreOficina { get; set; }
        public DateTime? DateReserva { get; set; }
        public int? IdEstado { get; set; }
        public string? descriptionEstado { get; set; }
    }
}
