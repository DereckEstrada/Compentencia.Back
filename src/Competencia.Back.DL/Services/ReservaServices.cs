using Competencia.Back.DAL.Interfaces;
using Competencia.Back.DL.Interfaces;
using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Back.DL.Services
{
    public class ReservaServices : IReservaServices
    {
        private readonly IReservaRepositorio _repositorio;
        public ReservaServices(IReservaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Result> DeleteReserva(ReservaPersona reserva)
        {
            var result = new Result();
            try
            {
                reserva.IdEstado = 2;
                result = await _repositorio.UpdateReserva(reserva);
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Result> GetReserva(QueryOptions queryFront)
        {
            var result = new Result();
            Expression<Func<ReservaPersona, bool>> query = reserva => false;
            try
            {
                switch (queryFront.Option)
                {
                    case "estado":
                        query = reserva => reserva.IdEstado == int.Parse(queryFront.Data);
                        break;
                    case "fecha":
                        query = reserva => reserva.DateReserva== DateTime.Parse(queryFront.Data);
                        break;
                    default:
                        throw new Exception("Opcion no valida");
                }
                result = await _repositorio.GetReserva(query);
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
                reserva.IdEstado = 1;
                reserva.DateReserva= DateTime.Now;  
                result = await _repositorio.UpdateReserva(reserva);
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
                result = await _repositorio.UpdateReserva(reserva);
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
