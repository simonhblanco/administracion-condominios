using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOAPServiceTest
{
    [TestClass]
    public class TestServVivienda
    {
        SRVivienda.ViviendasClient viviendasWS = new SRVivienda.ViviendasClient();

        SRVivienda.DVivienda vivienda = null;
        SRVivienda.DResidente residente = new SRVivienda.DResidente();

        [TestMethod]
        public void Test01Crear()
        {
            residente.DNI = "40717628";

            vivienda = new SRVivienda.DVivienda();

            vivienda.NumVivienda = 5;
            vivienda.Ubicacion = "San Borja";
            vivienda.Numero = 459;
            vivienda.Metraje = 200;
            vivienda.Tipo = "C";
            vivienda.Residente = residente;

            vivienda = viviendasWS.CrearVivienda(vivienda);

            Assert.IsNotNull(vivienda);
            Assert.IsTrue(vivienda.NumVivienda > 0);
        }

        [TestMethod]
        public void Test02Obtener()
        {
            vivienda = new SRVivienda.DVivienda();

            vivienda.NumVivienda = 1;

            vivienda = viviendasWS.ObtenerVivienda(vivienda.NumVivienda);

            Assert.IsNotNull(vivienda);
            Assert.AreEqual(vivienda.NumVivienda, 1);
            Assert.IsNotNull(vivienda.Tipo);
        }

        [TestMethod]
        public void Test03Modificar()
        {
            vivienda = new SRVivienda.DVivienda();

            vivienda.NumVivienda = 2;
            vivienda = viviendasWS.ObtenerVivienda(vivienda.NumVivienda);

            SRVivienda.DVivienda viviendaOriginal = viviendasWS.ObtenerVivienda(vivienda.NumVivienda);

            vivienda.Ubicacion = "Zarate";

            SRVivienda.DVivienda viviendaModificada = viviendasWS.ModificarVivienda(vivienda);

            Assert.IsNotNull(viviendaModificada);
            Assert.AreNotEqual(viviendaOriginal.Ubicacion, viviendaModificada.Ubicacion);
        }

        [TestMethod]
        public void Test04Listar()
        {
            ICollection<SRVivienda.DVivienda> LDVivienda = viviendasWS.ListarTodosLasViviendas();
            Assert.IsNotNull(LDVivienda);
            Assert.IsTrue(LDVivienda.Count > 0);
        }

        [TestMethod]
        public void Test05Eliminar()
        {
            vivienda = new SRVivienda.DVivienda();

            vivienda.NumVivienda = 5;

            //Assert.DoesNotThrow(delegate
            //{
            viviendasWS.EliminarVivienda(vivienda);
            //});

            vivienda = viviendasWS.ObtenerVivienda(vivienda.NumVivienda);
            Assert.IsNull(vivienda);
        }
    }
}
