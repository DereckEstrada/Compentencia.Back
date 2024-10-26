using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Back.DAL.Interfaces
{
    public interface IOficinaRepositorio
    {
        Task<Result> GetOficina();
        Task<Result> PostOficina(Oficina oficina);
        Task<Result> UpdateOficina(Oficina oficina);
    }
}
