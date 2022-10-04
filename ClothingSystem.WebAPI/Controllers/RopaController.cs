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
    [Authorize] // agregar el siguiente metadato para autorizar JWT la Web API
    public class RopaController : ControllerBase
    {
        private RopaBL ropaBL = new RopaBL();

        // GET: api/<RolController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Ropa>> Get()
        {
            return await ropaBL.ObtenerTodosAsync();
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public async Task<Ropa> Get(int id)
        {
            Ropa ropa = new Ropa();
            ropa.Id = id;
            return await ropaBL.ObtenerPorIdAsync(ropa);
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Ropa ropa)
        {
            try
            {
                await ropaBL.CrearAsync(ropa);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Ropa ropa)
        {

            if (ropa.Id == id)
            {
                await ropaBL.ModificarAsync(ropa);
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
                Ropa ropa = new Ropa();
                ropa.Id = id;
                await ropaBL.EliminarAsync(ropa);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Ropa>> Buscar([FromBody] object pRopa)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strRopa = JsonSerializer.Serialize(pRopa);
            Ropa ropa = JsonSerializer.Deserialize<Ropa>(strRopa, option);
            return await ropaBL.BuscarAsync(ropa);

        }
    }
}

