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
    public class Test02ViviendaDAO
    {
        private ViviendaDAO daoVivienda = new ViviendaDAO();

        [Test]
        public void Test01Crear()
        {
            // 1. Instancia el objeto TO
            Residente residente = new Residente();
            Vivienda pruebaVivienda = new Vivienda();

            // Agregamos los valores del objeto TO
            residente.DNI = "40717623";
            pruebaVivienda.Ubicacion = "Lima";
            pruebaVivienda.Numero = 459;
            pruebaVivienda.Metraje = 200;
            pruebaVivienda.Tipo = "C";
            pruebaVivienda.Residente = residente;

            // 3. Llamada al método del DAO a probar
            Vivienda viviendaCreada = daoVivienda.Crear(pruebaVivienda);

            // 4. Implementar las validaciones
            Assert.NotNull(viviendaCreada);
            Assert.AreEqual(pruebaVivienda.Ubicacion, viviendaCreada.Ubicacion);
        }

        [Test]
        public void Test02Obtener()
        {
            // 1. Instancia el objeto a probar
            Vivienda pruebaVivienda = new Vivienda();

            // 2. Instanciamos el objeto TO
            pruebaVivienda.NumVivienda = 3;

            // 3. Llamada al método del DAO a probar
            Vivienda viviendaObtenido = daoVivienda.Obtener(pruebaVivienda.NumVivienda);

            // 4. Implementar las validaciones
            Assert.NotNull(viviendaObtenido);
            Assert.AreEqual(pruebaVivienda.NumVivienda, viviendaObtenido.NumVivienda);
            Assert.NotNull(viviendaObtenido.Ubicacion);
        }

        [Test]
        public void Test03Modificar()
        {
            // 1. Instancia el objeto a probar
            Vivienda pruebaVivienda = new Vivienda();

            // 2. Instanciamos el objeto TO
            pruebaVivienda.NumVivienda = 3;
            pruebaVivienda = daoVivienda.Obtener(pruebaVivienda.NumVivienda);
            Vivienda viviendaOriginal = daoVivienda.Obtener(pruebaVivienda.NumVivienda);
            pruebaVivienda.Ubicacion = "Callao";

            // 3. Llamada al método del DAO a probar
            Vivienda viviendaModificado = daoVivienda.Modificar(pruebaVivienda);

            // 4. Implementar las validaciones
            Assert.NotNull(viviendaModificado);
            Assert.AreNotEqual(viviendaOriginal.Ubicacion, viviendaModificado.Ubicacion);
        }

        [Test]
        public void Test04Eliminar()
        {
            // 1. Instancia el objeto a probar
            Vivienda pruebaVivienda = new Vivienda();
            Residente residente = new Residente();

            // 2. Instanciamos el objeto TO
            pruebaVivienda.NumVivienda = 3;

            // 3. Llamada al método del DAO a probar
            Assert.DoesNotThrow(delegate
            {
                daoVivienda.Eliminar(pruebaVivienda);
            });

            pruebaVivienda = daoVivienda.Obtener(pruebaVivienda.NumVivienda);
            // 4. Implementar las validaciones
            Assert.Null(pruebaVivienda);
        }

        [Test]
        public void TestListar()
        {

        }
    }
}