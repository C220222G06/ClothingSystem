using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Agregar la siguiente librerias
using ClothingSystem.EntidadesDeNegocio;
using ClothingSystem.LogicaDeNegocio;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
namespace ClothingSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize] // agregar el siguiente metadato para autorizar JWT la Web API
    public class RopaFotoController : ControllerBase
    {
        private RopaFotoBL ropafotoBL = new RopaFotoBL();

        // GET: api/<RolController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<RopaFoto>> Get()
        {
            return await ropafotoBL.ObtenerTodosAsync();
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public async Task<RopaFoto> Get(int id)
        {
            RopaFoto ropafoto = new RopaFoto();
            ropafoto.Id = id;
            return await ropafotoBL.ObtenerPorIdAsync(ropafoto);
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RopaFoto ropafoto)
        {
            try
            {
                await ropafotoBL.CrearAsync(ropafoto);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RopaFoto ropafoto)
        {

            if (ropafoto.Id == id)
            {
                await ropafotoBL.ModificarAsync(ropafoto);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                RopaFoto ropafoto = new RopaFoto();
                ropafoto.Id = id;
                await ropafotoBL.EliminarAsync(ropafoto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<RopaFoto>> Buscar([FromBody] object pRopaFoto)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strRopaFoto = JsonSerializer.Serialize(pRopaFoto);
            RopaFoto ropafoto = JsonSerializer.Deserialize<RopaFoto>(strRopaFoto, option);
            return await ropafotoBL.BuscarAsync(ropafoto);

        }
    }
}

