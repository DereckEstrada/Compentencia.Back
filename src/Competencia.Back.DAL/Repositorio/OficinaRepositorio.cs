using Competencia.Back.DAL.Interfaces;
using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using Microsoft.EntityFrameworkCore;


namespace Competencia.Back.DAL.Repositorio
{
    public class OficinaRepositorio:IOficinaRepositorio
    {
        private readonly CompetenciaDbContext _context;
        private DynamicValidator dynamicEmpty = new DynamicValidator();
        public OficinaRepositorio(CompetenciaDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Result> GetOficina()
        {
            var result = new Result();
            try
            {
                result.Data = await _context.Oficinas.ToListAsync();
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

        public async Task<Result> PostOficina(Oficina oficina)
        {
            var result = new Result();
            try
            {
                _context.Oficinas.Add(oficina);
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

        public async Task<Result> UpdateOficina(Oficina oficina)
        {
            var result = new Result();
            try
            {
                _context.Oficinas.Update(oficina);
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
