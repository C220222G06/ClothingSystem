using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*****************************
using Microsoft.EntityFrameworkCore;
using ClothingSystem.EntidadesDeNegocio;
namespace ClothingSystem.AccesoADatos
{
    public class MarcaDAL
    {
        public static async Task<int> CrearAsync(Marca pMarca)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pMarca);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Marca pMarca)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var marca = await bdContexto.Marca.FirstOrDefaultAsync(s => s.Id == pMarca.Id);
                Marca pmarca = new Marca();
                //marca.Nombre = pMarca.Nombre;
                //marca.Descripcion = pMarca.Descripcion;
                //marca.PaisOrigen = pMarca.PaisOrigen;
                //bdContexto.Update(marca);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Marca pMarca)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var marca = await bdContexto.Marca.FirstOrDefaultAsync(s => s.Id == pMarca.Id);
                bdContexto.Marca.Remove(marca);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Marca> ObtenerPorIdAsync(Marca pMarca)
        {
            var marca = new Marca();
            using (var bdContexto = new BDContexto())
            {
                marca = await bdContexto.Marca.FirstOrDefaultAsync(s => s.Id == pMarca.Id);
            }
            return marca;
        }
        public static async Task<List<Marca>> ObtenerTodosAsync()
        {
            var marcas = new List<Marca>();
            using (var bdContexto = new BDContexto())
            {
                marcas = await bdContexto.Marca.ToListAsync();
            }
            return marcas;
        }
        internal static IQueryable<Marca> QuerySelect(IQueryable<Marca> pQuery, Marca pMarca)
        {
            if (pMarca.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pMarca.Id);
            if (!string.IsNullOrWhiteSpace(pMarca.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pMarca.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            //if (pMarca.Top_Aux > 0)
            //    pQuery = pQuery.Take(pMarca.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Marca>> BuscarAsync(Marca pMarca)
        {
            var marcas = new List<Marca>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Marca.AsQueryable();
                select = QuerySelect(select, pMarca);
                marcas = await select.ToListAsync();
            }
            return marcas;
        }
    }
}

