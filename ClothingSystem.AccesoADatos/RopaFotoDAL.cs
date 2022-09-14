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
    public class RopaFotoDAL
    {
        public static async Task<int> CrearAsync(RopaFoto pRopaFoto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pRopaFoto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(RopaFoto pRopaFoto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var ropafoto = await bdContexto.RopaFoto.FirstOrDefaultAsync(s => s.Id == pRopaFoto.Id);
                ropafoto.IdRopa = pRopaFoto.IdRopa;
                RopaFoto propafoto = new RopaFoto();
                ropafoto.Url = pRopaFoto.Url;
                bdContexto.Update(ropafoto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(RopaFoto pRopaFoto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var ropafoto = await bdContexto.RopaFoto.FirstOrDefaultAsync(s => s.Id == pRopaFoto.Id);
                bdContexto.RopaFoto.Remove(ropafoto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<RopaFoto> ObtenerPorIdAsync(RopaFoto pRopaFoto)
        {
            var ropafoto = new RopaFoto();
            using (var bdContexto = new BDContexto())
            {
                ropafoto = await bdContexto.RopaFoto.FirstOrDefaultAsync(s => s.Id == pRopaFoto.Id);
            }
            return ropafoto;
        }
        public static async Task<List<RopaFoto>> ObtenerTodosAsync()
        {
            var ropafotos = new List<RopaFoto>();
            using (var bdContexto = new BDContexto())
            {
                ropafotos = await bdContexto.RopaFoto.ToListAsync();
            }
            return ropafotos;
        }
        internal static IQueryable<RopaFoto> QuerySelect(IQueryable<RopaFoto> pQuery, RopaFoto pRopaFoto)
        {
            if (pRopaFoto.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pRopaFoto.Id);
            if (pRopaFoto.IdRopa > 0)
                pQuery = pQuery.Where(s => s.IdRopa == pRopaFoto.IdRopa);
            if (!string.IsNullOrWhiteSpace(pRopaFoto.Url))
                pQuery = pQuery.Where(s => s.Url.Contains(pRopaFoto.Url));
            if (pRopaFoto.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pRopaFoto.Estatus);
            if (pRopaFoto.Top_Aux > 0)
                pQuery = pQuery.Take(pRopaFoto.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<RopaFoto>> BuscarAsync(RopaFoto pRopaFoto)
        {
            var ropafotos = new List<RopaFoto>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.RopaFoto.AsQueryable();
                select = QuerySelect(select, pRopaFoto);
                ropafotos = await select.ToListAsync();
            }
            return ropafotos;
        }
        public static async Task<List<RopaFoto>> BuscarIncluirRopasAsync(RopaFoto pRopaFoto)
        {
            var ropafotos = new List<RopaFoto>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.RopaFoto.AsQueryable();
                select = QuerySelect(select, pRopaFoto).Include(s => s.Ropa).AsQueryable();
                ropafotos = await select.ToListAsync();
            }

            return ropafotos;
        }
    }
}

