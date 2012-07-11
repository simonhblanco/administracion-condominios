using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Condominios.Dominio;
using Condominios.Persistencia;

namespace Condominios.Pruebas
{
    [TestFixture]
    public class Test04TransaccionPagoDAO
    {
        private TransaccionPagoDAO transaccionPagoDAO = new TransaccionPagoDAO();

        [Test]
        public void Test01Crear()
        {
            Cuota llaveCuota = new Cuota();
            TransaccionPago pruebaTransaccionPago = new TransaccionPago();
            llaveCuota.IdCuota = 1;

            pruebaTransaccionPago.Cuota = llaveCuota;
            pruebaTransaccionPago.TipoPago = "E";
            pruebaTransaccionPago.FechaOperacion = System.DateTime.Now;

            TransaccionPago transaccionPagocreada = transaccionPagoDAO.Crear(pruebaTransaccionPago);

            Assert.NotNull(transaccionPagocreada);
            Assert.Greater(transaccionPagocreada.IdTransaccionPago, 0);
        }

        [Test]
        public void Test02Obtener()
        {
            TransaccionPago prueba = new TransaccionPago();
            prueba.IdTransaccionPago = 1;

            TransaccionPago transaccionPagoobtenida = transaccionPagoDAO.Obtener(prueba.IdTransaccionPago);

            Assert.NotNull(transaccionPagoobtenida);
            Assert.AreEqual(prueba.IdTransaccionPago, transaccionPagoobtenida.IdTransaccionPago);
            Assert.NotNull(transaccionPagoobtenida.TipoPago);
        }

        [Test]
        public void Test03Modificar()
        {
            TransaccionPago prueba = new TransaccionPago();
            prueba.IdTransaccionPago = 1;

            TransaccionPago pruebaTransaccionPago = transaccionPagoDAO.Obtener(prueba.IdTransaccionPago);
            pruebaTransaccionPago.TipoPago = "C";

            TransaccionPago transaccionPagomodificada = transaccionPagoDAO.Modificar(pruebaTransaccionPago);
            pruebaTransaccionPago = transaccionPagoDAO.Obtener(prueba.IdTransaccionPago);

            Assert.AreEqual(pruebaTransaccionPago.TipoPago, "C");
        }

        [Test]
        public void TestListar()
        {

        }

        [Test]
        public void Test04Eliminar()
        {
            TransaccionPago pruebaTransaccionPago = new TransaccionPago();
            pruebaTransaccionPago.IdTransaccionPago = 1;

            Assert.DoesNotThrow(delegate
            {
                transaccionPagoDAO.Eliminar(pruebaTransaccionPago);
            });

            pruebaTransaccionPago = transaccionPagoDAO.Obtener(pruebaTransaccionPago.IdTransaccionPago);

            Assert.Null(pruebaTransaccionPago);

        }
    }
}