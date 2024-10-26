using Competencia.Back.DAL.Interfaces;
using Competencia.Back.DL.Interfaces;
using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Back.DL.Services
{
    public class OficinaServices:IOficinaServices
    {
        private readonly IOficinaRepositorio _repositorio;
        public OficinaServices(IOficinaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Result> GetOficina()
        {
            var result = new Result();
            try
            {
                result = await _repositorio.GetOficina();
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
                result = await _repositorio.PostOficina(oficina);
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
                result = await _repositorio.UpdateOficina(oficina);
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
