using Competencia.Back.DAL.Interfaces;
using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Back.DAL.Repositorio
{
    public class PersonaRepositorio:IPersonaRepositorio
    {
       private readonly CompetenciaDbContext _context;
        private DynamicValidator dynamicEmpty=new DynamicValidator();
        public PersonaRepositorio(CompetenciaDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Result> GetPersona()
        {
            var result=new Result();
            try
            {
                result.Data=await _context.Personas.ToListAsync();
                result.Code = dynamicEmpty.IsDynamicEmpty(result.Data) ?"204"     : "200";
                result.Message = dynamicEmpty.IsDynamicEmpty(result.Data) ?"No hay data" : "OK";
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message=ex.Message;
            }
            return result;
        }

        public async Task<Result> PostPersona(Persona persona)
        {
            var result = new Result();
            try
            {
                _context.Personas.Add(persona);
                await _context.SaveChangesAsync();
                result.Code =  "201";
                result.Message =  "OK";
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Result> UpdatePersona(Persona pesona)
        {
            var result = new Result();
            try
            {
                _context.Personas.Update(pesona);
                await _context.SaveChangesAsync();
                result.Code = "201";
                result.Message = "OK";
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
