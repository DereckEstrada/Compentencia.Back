using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Back.DL.Interfaces
{
    public interface IPersonaServices
    {
        Task<Result> GetPersona();
        Task<Result> PostPersona(Persona pesona);
        Task<Result> UpdatePersona(Persona pesona);
    }
}
