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
    public class Test03CuotaDAO
    {
        private CuotaDAO daoCuota = new CuotaDAO();

        [Test]
        public void Test01Crear()
        {
            // 1. Instancia el objeto TO
            Vivienda vivienda = new Vivienda();
            Cuota pruebaCuota = new Cuota();

            // Agregamos los valores del objeto TO
            vivienda.NumVivienda = 1;
            pruebaCuota.Mes = "03";
            pruebaCuota.Anio = "2011";
            pruebaCuota.Importe = 2000;
            pruebaCuota.FechaVencimiento = DateTime.Now;
            pruebaCuota.Vivienda = vivienda;
            pruebaCuota.Estado = "P";

            // 3. Llamada al método del DAO a probar
            Cuota cuotaCreada = daoCuota.Crear(pruebaCuota);

            // 4. Implementar las validaciones
            Assert.NotNull(cuotaCreada);
            Assert.AreEqual(pruebaCuota.Mes, cuotaCreada.Mes);
        }

        [Test]
        public void Test02Obtener()
        {
            // 1. Instancia el objeto a probar
            Cuota pruebaCuota = new Cuota();

            // 2. Instanciamos el objeto TO
            pruebaCuota.IdCuota = 2;

            // 3. Llamada al método del DAO a probar
            Cuota cuotaObtenida = daoCuota.Obtener(pruebaCuota.IdCuota);

            // 4. Implementar las validaciones
            Assert.NotNull(cuotaObtenida);
            Assert.AreEqual(pruebaCuota.IdCuota, cuotaObtenida.IdCuota);
            Assert.NotNull(cuotaObtenida.Mes);
        }

        [Test]
        public void Test04Eliminar()
        {
            // 1. Instancia el objeto a probar
            Cuota pruebaCuota = new Cuota();
            
            // 2. Instanciamos el objeto TO
            pruebaCuota.IdCuota = 2;

            // 3. Llamada al método del DAO a probar
            Assert.DoesNotThrow(delegate
            {
                daoCuota.Eliminar(pruebaCuota);
            });

            // 4. Implementar las validaciones
            pruebaCuota = daoCuota.Obtener(pruebaCuota.IdCuota);
            Assert.Null(pruebaCuota);
        }

        [Test]
        public void Test03Modificar()
        {

            Cuota pruebaCuota = new Cuota();
            pruebaCuota.IdCuota = 2;
            pruebaCuota = daoCuota.Obtener(pruebaCuota.IdCuota);
            Cuota cuotaOriginal = daoCuota.Obtener(pruebaCuota.IdCuota);

            pruebaCuota.Importe = 3000;

            // 3. Llamada al método del DAO a probar
            Cuota cuotaModificada = daoCuota.Modificar(pruebaCuota);

            // 4. Implementar las validaciones
            Assert.NotNull(cuotaModificada);
            Assert.AreNotEqual(cuotaOriginal.Importe, cuotaModificada.Importe);
        }

        [Test]
        public void TestListar()
        {
            string estado = "P";
            DateTime fecha = DateTime.Now;
            ICollection<Cuota> LCuota = daoCuota.ListarMorosos(estado,fecha);
            Assert.NotNull(LCuota);
            Assert.Greater(LCuota.Count, 0);
        }
    }
}