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
    public class RopaDAL
    {
        public static async Task<int> CrearAsync(Ropa pRopa)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pRopa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Ropa pRopa)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var ropa = await bdContexto.Ropa.FirstOrDefaultAsync(s => s.Id == pRopa.Id);
                ropa.IdMarca = pRopa.IdMarca;
                ropa.CodigoBarra = pRopa.CodigoBarra;
                ropa.Nombre = pRopa.Nombre;
                ropa.PrecioCompra = pRopa.PrecioCompra;
                ropa.PrecioVenta = pRopa.PrecioVenta;
                ropa.PrecioVenta = pRopa.PrecioVenta;
                ropa.Existencia = pRopa.Existencia;
                ropa.Estatus = pRopa.Estatus;
                ropa.Talla = pRopa.Talla;
                ropa.Color = pRopa.Color;
                ropa.Estilo = pRopa.Estilo;
                ropa.Descripcion = pRopa.Descripcion;
                ropa.TipoTela = pRopa.TipoTela;
                bdContexto.Update(ropa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Ropa pRopa)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var ropa = await bdContexto.Ropa.FirstOrDefaultAsync(s => s.Id == pRopa.Id);
                bdContexto.Ropa.Remove(ropa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Ropa> ObtenerPorIdAsync(Ropa pRopa)
        {
            var ropa = new Ropa();
            using (var bdContexto = new BDContexto())
            {
                ropa = await bdContexto.Ropa.FirstOrDefaultAsync(s => s.Id == pRopa.Id);
            }
            return ropa;
        }
        public static async Task<List<Ropa>> ObtenerTodosAsync()
        {
            var ropas = new List<Ropa>();
            using (var bdContexto = new BDContexto())
            {
                ropas = await bdContexto.Ropa.ToListAsync();
            }
            return ropas;
        }
        internal static IQueryable<Ropa> QuerySelect(IQueryable<Ropa> pQuery, Ropa pRopa)
        {
            if (pRopa.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pRopa.Id);
            if (pRopa.IdMarca > 0)
                pQuery = pQuery.Where(s => s.IdMarca == pRopa.IdMarca);
            if (!string.IsNullOrWhiteSpace(pRopa.CodigoBarra))
                pQuery = pQuery.Where(s => s.CodigoBarra.Contains(pRopa.CodigoBarra));
            if (!string.IsNullOrWhiteSpace(pRopa.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pRopa.Nombre));
            if (pRopa.PrecioCompra > 0)
                pQuery = pQuery.Where(s => s.PrecioCompra == pRopa.PrecioCompra);
            if (pRopa.PrecioVenta > 0)
                pQuery = pQuery.Where(s => s.PrecioVenta == pRopa.PrecioVenta);
            if (pRopa.Existencia > 0)
                pQuery = pQuery.Where(s => s.Existencia == pRopa.Existencia);
            if (pRopa.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pRopa.Estatus);
            if (!string.IsNullOrWhiteSpace(pRopa.Talla))
                pQuery = pQuery.Where(s => s.Talla.Contains(pRopa.Talla));
            if (!string.IsNullOrWhiteSpace(pRopa.Color))
                pQuery = pQuery.Where(s => s.Color.Contains(pRopa.Color));
            if (!string.IsNullOrWhiteSpace(pRopa.Estilo))
                pQuery = pQuery.Where(s => s.Estilo.Contains(pRopa.Estilo));
            if (!string.IsNullOrWhiteSpace(pRopa.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pRopa.Descripcion));
            if (!string.IsNullOrWhiteSpace(pRopa.TipoTela))
                pQuery = pQuery.Where(s => s.TipoTela.Contains(pRopa.TipoTela));
            if (pRopa.Top_Aux > 0)
                pQuery = pQuery.Take(pRopa.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Ropa>> BuscarAsync(Ropa pRopa)
        {
            var ropas = new List<Ropa>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Ropa.AsQueryable();
                select = QuerySelect(select, pRopa);
                ropas = await select.ToListAsync();
            }
            return ropas;
        }
        public static async Task<List<Ropa>> BuscarIncluirMarcasAsync(Ropa pRopa)
        {
            var ropas = new List<Ropa>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Ropa.AsQueryable();
                select = QuerySelect(select, pRopa).Include(s => s.Marca).AsQueryable();
                ropas = await select.ToListAsync();
            }

            return ropas;
        }
    }
}

