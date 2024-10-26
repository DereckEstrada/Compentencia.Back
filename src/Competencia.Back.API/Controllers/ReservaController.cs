using Competencia.Back.DL.Interfaces;
using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Competencia.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServices _services;
        public ReservaController(IReservaServices services)
        {
            this._services = services;
        }
        [HttpPost("GetReserva")]
        public async Task<Result> GetReserva(QueryOptions query)
        {
            var result = new Result();
            try
            {
                result = await _services.GetReserva(query);
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost("PostReserva")]
        public async Task<Result> PostReserva(ReservaPersona reserva)
        {
            var result=new Result();
            try
            {
                result = await _services.PostReserva(reserva);
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost("UpdateReserva")]
        public async Task<Result> UpdateReserva(ReservaPersona reserva)
        {
            var result=new Result();
            try
            {
                result = await _services.UpdateReserva(reserva);
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost("DeleteReserva")]
        public async Task<Result> DeleteReserva(ReservaPersona reserva)
        {
            var result=new Result();
            try
            {
                result = await _services.DeleteReserva(reserva);
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
