
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//***************************

using ClothingSystem.AccesoADatos;
using ClothingSystem.EntidadesDeNegocio;

namespace ClothingSystem.LogicaDeNegocio
{
    public class RopaBL
    {
        #region CRUD
        public async Task<int> CrearAsync(Ropa pRopa)
        {
            return await RopaDAL.CrearAsync(pRopa);
        }
        public async Task<int> ModificarAsync(Ropa pRopa)
        {
            return await RopaDAL.ModificarAsync(pRopa);
        }
        public async Task<int> EliminarAsync(Ropa pRopa)
        {
            return await RopaDAL.EliminarAsync(pRopa);
        }
        public async Task<Ropa> ObtenerPorIdAsync(Ropa pRopa)
        {
            return await RopaDAL.ObtenerPorIdAsync(pRopa);
        }
        public async Task<List<Ropa>> ObtenerTodosAsync()
        {
            return await RopaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Ropa>> BuscarAsync(Ropa pRopa)
        {
            return await RopaDAL.BuscarAsync(pRopa);
        }
        #endregion
        public async Task<List<Ropa>> BuscarIncluirMarcasAsync(Ropa pRopa)
        {
            return await RopaDAL.BuscarIncluirMarcasAsync(pRopa);
        }
    }
}