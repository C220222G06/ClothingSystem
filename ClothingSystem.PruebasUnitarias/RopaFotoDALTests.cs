using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClothingSystem.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClothingSystem.EntidadesDeNegocio;

namespace ClothingSystem.AccesoADatos.Tests
{
    [TestClass()]
    public class RopaFotoDALTests
    {
        private static RopaFoto ropafotoInicial = new RopaFoto { Id = 2 };  // Agregar un id existente en la base de datos 
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var ropafoto = new RopaFoto();
            ropafoto.IdRopa = ropafotoInicial.IdRopa;
            ropafoto.Url = "heudherudhuehdue";
            ropafoto.Estatus = (byte)Estatus_RopaFoto.INACTIVO;
            int result = await RopaFotoDAL.CrearAsync(ropafoto);
 //           Assert.AreNotEqual(0, result);
            ropafotoInicial.Id = ropafoto.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var ropafoto = new RopaFoto();
            ropafoto.IdRopa = ropafotoInicial.IdRopa;
            ropafoto.Id = ropafotoInicial.Id;
            ropafoto.Url = "heudherudhuehdue";
            ropafoto.Estatus = (byte)Estatus_RopaFoto.ACTIVO;
            int result = await RopaFotoDAL.ModificarAsync(ropafoto);
//            Assert.AreNotEqual(0, result);
        }
        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var ropafoto = new RopaFoto();
            ropafoto.Id = ropafotoInicial.Id;
            var resultRopaFoto = await RopaFotoDAL.ObtenerPorIdAsync(ropafoto);
//            Assert.AreEqual(ropafoto.Id, resultRopaFoto.Id);
        }
        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultRopas = await RopaFotoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultRopas.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var ropafoto = new RopaFoto();
            ropafoto.Url = "a";
            ropafoto.Top_Aux = 10;
            ropafoto.Estatus = (byte)Estatus_RopaFoto.ACTIVO;
            ropafoto.Top_Aux = 10;
            var resultRopas = await RopaFotoDAL.BuscarAsync(ropafoto);
            Assert.AreNotEqual(0, resultRopas.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var ropafoto = new RopaFoto();
            ropafoto.Id = ropafotoInicial.Id;
            int result = await RopaFotoDAL.EliminarAsync(ropafoto);
            Assert.AreNotEqual(0, result);
        }


        [TestMethod()]
        public async Task T7BuscarIncluirRopasAsyncTest()
        {
            var ropafoto = new RopaFoto();
            RopaFoto ropaFoto = new RopaFoto();
            ropafoto.IdRopa = ropafotoInicial.IdRopa;
            ropafoto.Url = "A ";
            ropafoto.Estatus = (byte)Estatus_RopaFoto.ACTIVO;
            ropafoto.Top_Aux = 10;
            var resultRopas = await RopaFotoDAL.BuscarIncluirRopasAsync(ropafoto);
            Assert.AreNotEqual(1, resultRopas.Count);
        }
    }
}