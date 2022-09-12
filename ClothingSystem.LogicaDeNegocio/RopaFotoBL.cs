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
    public class RopaFotoBL
    {
        #region CRUD
        public async Task<int> CrearAsync(RopaFoto pRopaFoto)
        {
            return await RopaFotoDAL.CrearAsync(pRopaFoto);
        }
        public async Task<int> ModificarAsync(RopaFoto pRopaFoto)
        {
            return await RopaFotoDAL.ModificarAsync(pRopaFoto);
        }
        public async Task<int> EliminarAsync(RopaFoto pRopaFoto)
        {
            return await RopaFotoDAL.EliminarAsync(pRopaFoto);
        }
        public async Task<RopaFoto> ObtenerPorIdAsync(RopaFoto pRopaFoto)
        {
            return await RopaFotoDAL.ObtenerPorIdAsync(pRopaFoto);
        }
        public async Task<List<RopaFoto>> ObtenerTodosAsync()
        {
            return await RopaFotoDAL.ObtenerTodosAsync();
        }
        public async Task<List<RopaFoto>> BuscarAsync(RopaFoto pRopaFoto)
        {
            return await RopaFotoDAL.BuscarAsync(pRopaFoto);
        }
        public async Task<List<RopaFoto>> BuscarIncluirRopasAsync(RopaFoto pRopaFoto)
        {
            return await RopaFotoDAL.BuscarIncluirRopasAsync(pRopaFoto);
        }
    }
}
#endregion