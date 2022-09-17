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
    public class MarcaController : ControllerBase
    {
        private MarcaBL marcaBL = new MarcaBL();

        // GET: api/<RolController>
        [HttpGet]
        public async Task<IEnumerable<Marca>> Get()
        {
            return await marcaBL.ObtenerTodosAsync();
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public async Task<Marca> Get(int id)
        {
            Marca marca = new Marca();
            marca.Id = id;
            return await marcaBL.ObtenerPorIdAsync(marca);
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Marca marca)
        {
            try
            {
                await marcaBL.CrearAsync(marca);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Marca marca)
        {

            if (marca.Id == id)
            {
                await marcaBL.ModificarAsync(marca);
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
                Marca marca = new Marca();
                marca.Id = id;
                await marcaBL.EliminarAsync(marca);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Marca>> Buscar([FromBody] object pMarca)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strMarca = JsonSerializer.Serialize(pMarca);
            Marca marca = JsonSerializer.Deserialize<Marca>(strMarca, option);
            return await marcaBL.BuscarAsync(marca);

        }
    }
}

