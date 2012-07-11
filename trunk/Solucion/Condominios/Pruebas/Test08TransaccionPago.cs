using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;
using Condominios.Negocio;
using Condominios.Dominio;

namespace Condominios.Pruebas
{
    [TestFixture]
    public class Test08TransaccionPago
    {
        private IApplicationContext Spring;

        [TestFixtureSetUp]
        public void InicializarPruebas()
        {
            //"assembly://assembly/namespace/capaPersistencia.xml",
            Spring = new XmlApplicationContext(
                "assembly://Condominios/Condominios/capaPersistencia.xml",
                "assembly://Condominios/Condominios/capaNegocio.xml"
                );

            //Preparando el escenario de Pruebas

        }

        [Test]
        public void Test02MostrarCuota()
        {
            TransaccionService transaccionService = (TransaccionService)Spring.GetObject("transaccionService");

            Cuota cuotaObtenida = transaccionService.MostrarCuota(1);

            Assert.NotNull(cuotaObtenida);
            Assert.AreEqual(cuotaObtenida.IdCuota,1);
            Assert.NotNull(cuotaObtenida.Mes);
        }

        [Test]
        public void Test03PagarCuota()
        {
            TransaccionService transaccionService = (TransaccionService)Spring.GetObject("transaccionService");

            transaccionService.PagarCuota(3, "E");

            Cuota cuotaObtenida = transaccionService.MostrarCuota(3);

            Assert.NotNull(cuotaObtenida);
            Assert.AreEqual(cuotaObtenida.IdCuota, 3);
            Assert.AreEqual(cuotaObtenida.Estado,"C");
        }

        [Test]
        public void Test01ColocarCuota()
        {
            // 1. Instancia el objeto a probar
            Cuota crearCuota = new Cuota();
            Vivienda vivienda = new Vivienda();

            // 2. Instanciando el objeto TO
            vivienda.NumVivienda = 1;
            crearCuota.Mes = "03";
            crearCuota.Anio = "2011";
            crearCuota.Importe = 2000;
            crearCuota.FechaVencimiento = DateTime.Now;
            crearCuota.Vivienda = vivienda;
            crearCuota.Estado = "P";

            //ReservaService reservaService = new ReservaService();
            TransaccionService transaccionService = (TransaccionService)Spring.GetObject("transaccionService");
            Assert.NotNull(transaccionService);
            Cuota cuota = null;
            Assert.DoesNotThrow(delegate
            {
                cuota = transaccionService.ColocarCuota(crearCuota);
            });

            Assert.NotNull(cuota);
            
            //cuota duplicada
            //'02','2011',1024,SYSDATETIME(),2,'P'
            Cuota cuotaExistente = new Cuota();
            vivienda.NumVivienda = 2;
            cuotaExistente.Vivienda = vivienda;
            cuotaExistente.Anio = "2011";
            cuotaExistente.Mes = "02";
            Assert.Catch<Exception>(delegate
            {
                transaccionService.ColocarCuota(cuotaExistente);
            });
            
        }

        [Test]
        public void Test04ListarMorosos()
        {
            TransaccionService transaccionService = (TransaccionService)Spring.GetObject("transaccionService");
            Assert.NotNull(transaccionService);

            ICollection<Cuota> LCuota = transaccionService.ConsultarMorosos("P",DateTime.Now);
            Assert.NotNull(LCuota);
            Assert.Greater(LCuota.Count, 0);

            for (int i = 0; i < LCuota.Count; i++)
            {
                Assert.AreEqual(LCuota.ElementAt(i).Estado, "P");
            }

            //limpiar datos prueba
            /*Cuota cuotaBorrar = new Cuota();
            TransaccionPago transaccionBorrar = new TransaccionPago();

            cuotaBorrar.IdCuota = 3;
            transaccionBorrar.IdTransaccionPago = 1;

            transaccionService.transaccionPagoDAO.Eliminar(transaccionBorrar);
            transaccionService.CuotaDAO.Eliminar(cuotaBorrar);*/
        }
    }
}