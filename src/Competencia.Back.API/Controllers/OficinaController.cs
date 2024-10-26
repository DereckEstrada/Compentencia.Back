using Competencia.Back.DL.Interfaces;
using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Competencia.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficinaController : ControllerBase
    {
        private readonly IOficinaServices _services;
        public OficinaController(IOficinaServices services)
        {
            this._services = services;
        }
        [HttpGet("GetOficina")]
        public async Task<Result> GetOficina()
        {
            var result = new Result();
            try
            {
                result = await _services.GetOficina();
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost("PostOficina")]
        public async Task<Result> PostOficina(Oficina oficina)
        {
            var result = new Result();
            try
            {
                result = await _services.PostOficina(oficina);
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPut("UpdateOficina")]
        public async Task<Result> UpdateOficina(Oficina oficina)
        {
            var result = new Result();
            try
            {
                result = await _services.UpdateOficina(oficina);
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
