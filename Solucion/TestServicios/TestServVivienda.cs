using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOAPService.Persistencia;
using SOAPService.Dominio;

namespace TestServicios
{
    [TestClass]
    public class TestServVivienda
    {
        ViviendaDAO viviendaDAO = new ViviendaDAO();
        ResidenteDAO residenteDAO = new ResidenteDAO();
        DResidente residente = new DResidente();

        [TestMethod]
        public void Test01Crear()
        {
            DResidente residente = new DResidente();
            ResidenteDAO residenteDAO = new ResidenteDAO();

            residente = residenteDAO.Obtener("40717626");

            DVivienda r = viviendaDAO.Crear(new DVivienda()
            {
                NumVivienda = 1,
                Ubicacion = "San Borja",
                Numero = 459,
                Metraje = 200,
                Tipo = "C",
                Residente = residente
            });

            Assert.AreEqual(r.NumVivienda, 1);
        }

        [TestMethod]
        public void Test02Obtener()
        {
            // 1. Instancia el objeto a probar
            DVivienda pruebaVivienda = new DVivienda();

            // 2. Instanciamos el objeto TO
            pruebaVivienda.NumVivienda = 1;

            // 3. Llamada al método del DAO a probar
            DVivienda viviendaObtenida = viviendaDAO.Obtener(pruebaVivienda.NumVivienda);

            // 4. Implementar las validaciones
            Assert.IsNotNull(viviendaObtenida);
            Assert.AreEqual(pruebaVivienda.NumVivienda, viviendaObtenida.NumVivienda);
            Assert.IsNotNull(viviendaObtenida.Numero);
        }

        [TestMethod]
        public void Test03Modificar()
        {
            // 1. Instancia el objeto a probar
            DVivienda pruebaVivienda = new DVivienda();

            // 2. Instanciamos el objeto TO
            pruebaVivienda.NumVivienda = 1;
            pruebaVivienda = viviendaDAO.Obtener(pruebaVivienda.NumVivienda);
            DVivienda viviendaOriginal = viviendaDAO.Obtener(pruebaVivienda.NumVivienda);
            pruebaVivienda.Ubicacion = "Callao";

            // 3. Llamada al método del DAO a probar
            DVivienda viviendaModificado = viviendaDAO.Modificar(pruebaVivienda);

            // 4. Implementar las validaciones
            Assert.IsNotNull(viviendaModificado);
            Assert.AreNotEqual(viviendaOriginal.Ubicacion, viviendaModificado.Ubicacion);
        }

        [TestMethod]
        public void Test04Eliminar()
        {
            // 1. Instancia el objeto a probar
            DVivienda pruebaVivienda = new DVivienda();
            DResidente residente = new DResidente();

            // 2. Instanciamos el objeto TO
            pruebaVivienda.NumVivienda = 3;

            // 3. Llamada al método del DAO a probar
            //Assert.DoesNotThrow(delegate
            //{
            viviendaDAO.Eliminar(pruebaVivienda);
            //});

            pruebaVivienda = viviendaDAO.Obtener(pruebaVivienda.NumVivienda);
            // 4. Implementar las validaciones
            Assert.IsNull(pruebaVivienda);
        }

        [TestMethod]
        public void Test05Listar()
        {
            ICollection<DVivienda> LDVivienda = viviendaDAO.ListarTodos();
            Assert.IsNotNull(LDVivienda);
            Assert.IsTrue(LDVivienda.Count > 0);
        }
    }
}
