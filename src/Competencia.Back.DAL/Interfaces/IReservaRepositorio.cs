using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Back.DAL.Interfaces
{
    public interface IReservaRepositorio
    {
        Task<Result> GetReserva(Expression<Func<ReservaPersona, bool>> query);
        Task<Result> PostReserva(ReservaPersona reserva);
        Task<Result> UpdateReserva(ReservaPersona reserva);

    }
}
