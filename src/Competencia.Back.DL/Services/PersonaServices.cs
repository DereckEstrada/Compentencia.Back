using Competencia.Back.DAL.Interfaces;
using Competencia.Back.DL.Interfaces;
using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Back.DL.Services
{
    public class PersonaServices : IPersonaServices
    {
        private readonly IPersonaRepositorio _repositorio;
        public PersonaServices(IPersonaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Result> GetPersona()
        {
            var result = new Result();
            try
            {
                result=await _repositorio.GetPersona();
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Result> PostPersona(Persona persona)
        {
            var result = new Result();
            try
            {
                result = await _repositorio.PostPersona(persona);
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Result> UpdatePersona(Persona persona)
        {
            var result = new Result();
            try
            {
                result = await _repositorio.UpdatePersona(persona);
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
