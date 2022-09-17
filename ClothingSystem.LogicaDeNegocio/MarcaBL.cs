using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//***************************
using ClothingSystem.EntidadesDeNegocio;
using ClothingSystem.AccesoADatos;
namespace ClothingSystem.LogicaDeNegocio
{
    public class MarcaBL
    {
        public async Task<int> CrearAsync(Marca pMarca)
        {
            return await MarcaDAL.CrearAsync(pMarca);
        }
        public async Task<int> ModificarAsync(Marca pMarca)
        {
            return await MarcaDAL.ModificarAsync(pMarca);
        }
        public async Task<int> EliminarAsync(Marca pMarca)
        {
            return await MarcaDAL.EliminarAsync(pMarca);
        }
        public async Task<Marca> ObtenerPorIdAsync(Marca pMarca)
        {
            return await MarcaDAL.ObtenerPorIdAsync(pMarca);
        }
        public async Task<List<Marca>> ObtenerTodosAsync()
        {
            return await MarcaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Marca>> BuscarAsync(Marca pMarca)
        {
            return await MarcaDAL.BuscarAsync(pMarca);
        }
    }
}
