using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClothingSystem.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClothingSystem.EntidadesDeNegocio;

using System.ComponentModel;
using NuGet.Frameworks;
using System.Net.Http.Headers;

namespace ClothingSystem.AccesoADatos.Tests
{
    [TestClass()]
    public class RopaDALTests
    {
        private static Ropa ropaInicial = new Ropa { Id = 6, IdMarca = 3 }; //Agregar un Id existente en la base de datos
        [TestMethod()]
        public async Task T1CrearAsyncTest()     // Nombre, Existencia.., Estatus.., Talla, Color, Estilo, Descripcion, TipoTela
        {
            var ropa = new Ropa();
            ropa.IdMarca = ropaInicial.IdMarca;
            ropa.CodigoBarra = "hdeudheudhe";
            ropa.Nombre = "pantalon";
            ropa.Existencia = 25;
            ropa.Estatus = (byte)Estatus_Ropa.ACTIVO;
            ropa.Talla = "32";
            ropa.Color = "azul";
            ropa.Estilo = "liso";
            ropa.Descripcion = "euhdeuhde";
            ropa.TipoTela = "ajada";
            int result = await RopaDAL.CrearAsync(ropa);
            Assert.AreNotEqual(0, result);
            ropaInicial.Id = ropa.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var ropa = new Ropa();
            ropa.Id = ropaInicial.Id;
            ropa.IdMarca = ropaInicial.IdMarca;
            ropa.CodigoBarra = "Nuevo";
            ropa.Nombre = "PAN";
            ropa.Existencia = 25;
            ropa.Estatus = (byte)Estatus_Ropa.ACTIVO;
            ropa.Talla = "35";
            ropa.Color = "azul";
            ropa.Estilo = "liso";
            ropa.Descripcion = "euhdeuhde";
            ropa.TipoTela = "ajada";
            int result = await RopaDAL.ModificarAsync(ropa);
            Assert.AreNotEqual(0, result);
            ropaInicial.Id = ropa.Id;
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var ropa = new Ropa();
            ropa.Id = ropaInicial.Id;
            var resultRopa = await RopaDAL.ObtenerPorIdAsync(ropa);
            Assert.AreEqual(ropa.Id, resultRopa.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultRopas = await RopaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultRopas.Count);
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTest()
        {
            var ropa = new Ropa();
            ropa.IdMarca = ropaInicial.IdMarca;
            ropa.CodigoBarra = "A";
            ropa.Nombre = "a";
            ropa.Existencia = 25;
            ropa.Estatus = (byte)Estatus_Ropa.ACTIVO;
            ropa.Talla = "XLX";
            ropa.Color = "a";
            ropa.Estilo = "l";
            ropa.Descripcion = "e";
            ropa.TipoTela = "a";
            var resultRopas = await RopaDAL.BuscarAsync(ropa);
            Assert.AreEqual(0, resultRopas.Count);
            
        }

        [TestMethod()]
        public async Task T8BuscarIncluirMarcasAsyncTest()
        {
            var ropa = new Ropa();
            ropa.IdMarca = ropaInicial.IdMarca;
            ropa.CodigoBarra = "H";
            ropa.Nombre = "P";
            ropa.Existencia = 25;
            ropa.Estatus = (byte)Estatus_Ropa.ACTIVO;
            ropa.Talla = "3";
            ropa.Color = "A";
            ropa.Estilo = "L";
            ropa.Descripcion = "E";
            ropa.TipoTela = "A";
            var resultRopas = await RopaDAL.BuscarIncluirMarcasAsync(ropa);
            Assert.AreNotEqual(0, resultRopas.Count);
            var ultimaRopa = resultRopas.FirstOrDefault();
            Assert.IsTrue(ultimaRopa != null && ropa.IdMarca == ultimaRopa.Marca.Id);
        }

        [TestMethod()]
        public async Task T93EliminarAsyncTest()
        {
            var ropa = new Ropa();
            ropa.Id = ropaInicial.Id;
            int result = await RopaDAL.EliminarAsync(ropa);
            Assert.AreNotEqual(0, result);
        }
    }
}