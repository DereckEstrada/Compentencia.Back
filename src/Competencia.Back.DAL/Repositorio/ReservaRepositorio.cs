using Competencia.Back.DAL.Interfaces;
using Competencia.Back.DTOs;
using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Back.DAL.Repositorio
{
    public class ReservaRepositorio:IReservaRepositorio
    {
        private readonly CompetenciaDbContext _context;
        private DynamicValidator dynamicEmpty = new DynamicValidator();
        public ReservaRepositorio(CompetenciaDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Result> GetReserva(Expression<Func<ReservaPersona, bool>> query)
        {
            var result = new Result();
            try
            {
                result.Data = await _context.ReservaPersonas.Where(query).Include(reserva=>reserva.IdPersonaNavigation).
                    Include(reserva=>reserva.IdOficinaNavigation).Select(reserva=>new ReservaDTO
                    {
                        IdReservaPersona=reserva.IdPersona,
                        IdPersona=reserva.IdPersona,
                        cedulaPersona=reserva.IdPersonaNavigation.CedulaPersona,
                        IdOficina=reserva.IdOficina,
                        nombreOficina=reserva.IdOficinaNavigation.NombreOficina,
                        DateReserva=reserva.DateReserva,
                        IdEstado=reserva.IdEstado,
                        descriptionEstado=reserva.IdEstadoNavigation.DescriptionEstado,

                    })
                    .ToListAsync();
                result.Code = dynamicEmpty.IsDynamicEmpty(result.Data) ? "204" : "200";
                result.Message = dynamicEmpty.IsDynamicEmpty(result.Data) ? "No hay data" : "OK";
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Result> PostReserva(ReservaPersona reserva)
        {
            var result = new Result();
            try
            {
                _context.ReservaPersonas.Add(reserva);
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

        public async Task<Result> UpdateReserva(ReservaPersona reserva)
        {
            var result = new Result();
            try
            {
                _context.ReservaPersonas.Update(reserva);
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
