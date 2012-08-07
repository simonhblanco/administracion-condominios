using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOAPService.Dominio;
using SOAPService.Persistencia;

namespace TestServicios
{
    [TestClass]
    public class TestServCuota
    {
        DCuota cuotaCreada = new DCuota();
        CuotaDAO cuotaDao = new CuotaDAO();

        [TestMethod]
        public void Test01Crear()
        {

            DVivienda vivienda = new DVivienda();
            ViviendaDAO viviendaDAO = new ViviendaDAO();

            vivienda = viviendaDAO.Obtener(1);

            cuotaCreada.IdCuota = 2;
            cuotaCreada.Mes = "01";
            cuotaCreada.Anio = "2011";
            cuotaCreada.Importe = 2000.00;
            cuotaCreada.FechaVencimiento = DateTime.Now;
            cuotaCreada.Vivienda = vivienda;
            cuotaCreada.Estado = "P";

            cuotaCreada = cuotaDao.Crear(cuotaCreada);
            Assert.IsNotNull(cuotaCreada);
            Assert.IsTrue(cuotaCreada.IdCuota > 0);
        }

        [TestMethod]
        public void Test02Obtener()
        {
            // 1. Instancia el objeto a probar
            DCuota pruebaCuota = new DCuota();

            // 2. Instanciamos el objeto TO
            pruebaCuota.IdCuota = 1;

            // 3. Llamada al método del DAO a probar
            DCuota cuotaObtenida = cuotaDao.Obtener(pruebaCuota.IdCuota);

            // 4. Implementar las validaciones
            Assert.IsNotNull(cuotaObtenida);
            Assert.AreEqual(pruebaCuota.IdCuota, cuotaObtenida.IdCuota);
            Assert.IsNotNull(cuotaObtenida.Mes);
        }

        [TestMethod]
        public void Test03Eliminar()
        {
            // 1. Instancia el objeto a probar
            DCuota pruebaCuota = new DCuota();

            // 2. Instanciamos el objeto TO
            pruebaCuota.IdCuota = 2;

            // 3. Llamada al método del DAO a probar
            //Assert.DoesNotThrow(delegate
            //{
                cuotaDao.Eliminar(pruebaCuota);
            //});

            // 4. Implementar las validaciones
            pruebaCuota = cuotaDao.Obtener(pruebaCuota.IdCuota);
            Assert.IsNull(pruebaCuota);
        }

        [TestMethod]
        public void Test04Modificar()
        {
            DCuota pruebaCuota = new DCuota();

            pruebaCuota.IdCuota = 2;
            pruebaCuota = cuotaDao.Obtener(pruebaCuota.IdCuota);
            
            DCuota cuotaOriginal = cuotaDao.Obtener(pruebaCuota.IdCuota);

            pruebaCuota.Mes = "05";

            // 3. Llamada al método del DAO a probar
            DCuota cuotaModificada = cuotaDao.Modificar(pruebaCuota);

            // 4. Implementar las validaciones
            Assert.IsNotNull(cuotaModificada);
            Assert.AreNotEqual(cuotaOriginal.Mes, cuotaModificada.Mes);
        }

        [TestMethod]
        public void Test05Listar()
        {
            ICollection<DCuota> LDCuota = cuotaDao.ListarTodos();
            Assert.IsNotNull(LDCuota);
            Assert.AreEqual(LDCuota.Count, 0);
        }
    }
}
