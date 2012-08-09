using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOAPServiceTest.SRCuota;

namespace SOAPServiceTest
{
    [TestClass]
    public class TestServCuota
    {
        SRCuota.CuotaClient cuotaWS = new SRCuota.CuotaClient();

        SRCuota.DCuota cuota = null;

        SRCuota.DVivienda vivienda = new SRCuota.DVivienda();

        [TestMethod]
        public void Test01Crear()
        {
            vivienda.NumVivienda = 1;

            cuota = new SRCuota.DCuota();

            cuota.IdCuota = 6;
            cuota.Mes = "01";
            cuota.Anio = "2011";
            cuota.Importe = 2000;
            cuota.FechaVencimiento = DateTime.Now;
            cuota.Vivienda = vivienda;
            cuota.Estado = "P";

            cuota = cuotaWS.CrearCuota(cuota);
            Assert.IsNotNull(cuota);
            Assert.IsTrue(cuota.IdCuota > 0);
        }

        [TestMethod]
        public void Test02Obtener()
        {
            cuota = new SRCuota.DCuota();

            cuota.IdCuota = 6;

            cuota = cuotaWS.ObtenerCuota(cuota.IdCuota);

            Assert.IsNotNull(cuota);
            Assert.AreEqual(cuota.Importe, 6);
            Assert.IsNotNull(cuota.Mes);
        }

        [TestMethod]
        public void Test03Modificar()
        {
            cuota = new SRCuota.DCuota();

            cuota.IdCuota = 6;
            cuota = cuotaWS.ObtenerCuota(cuota.IdCuota);

            SRCuota.DCuota cuotaOriginal = cuotaWS.ObtenerCuota(cuota.IdCuota);

            cuota.Importe = 2800;

            SRCuota.DCuota cuotaModificada = cuotaWS.ModificarCuota(cuota);

            Assert.IsNotNull(cuotaModificada);
            Assert.AreNotEqual(cuotaOriginal.Importe, cuotaModificada.Importe);
        }

        [TestMethod]
        public void Test04Listar()
        {
            ICollection<SRCuota.DCuota> LDCuota = cuotaWS.ListarCuotas();
            Assert.IsNotNull(LDCuota);
            Assert.IsTrue(LDCuota.Count > 0);
        }

        [TestMethod]
        public void Test05Eliminar()
        {
            cuota = new SRCuota.DCuota();

            cuota.IdCuota = 6;

            //Assert.DoesNotThrow(delegate
            //{
            cuotaWS.EliminarCuota(cuota.IdCuota);
            //});

            cuota = cuotaWS.ObtenerCuota(cuota.IdCuota);
            Assert.IsNull(cuota);
        }

    }
}
