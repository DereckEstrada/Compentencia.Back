using Competencia.Back.DL.Interfaces;
using Competencia.Back.Entities.Entities;
using Competencia.Back.Entities.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Competencia.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaServices _services;
        public PersonaController(IPersonaServices  services)
        {
            this._services = services;
        }
        [HttpGet("GetPersona")]
        public async Task<Result> GetPersona()
        {
            var result = new Result();
            try
            {
                result = await _services.GetPersona();
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost("PostPersona")]
        public async Task<Result> PostPersona(Persona persona)
        {
            var result = new Result();
            try
            {
                result = await _services.PostPersona(persona);
            }
            catch (Exception ex)
            {

                result.Code = "400";
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPut("UpdatePersona")]
        public async Task<Result> UpdatePersona(Persona persona)
        {
            var result = new Result();
            try
            {
                result = await _services.UpdatePersona(persona);
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
