using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;
using Condominios.Persistencia;
using Condominios.Negocio;
using Condominios.Dominio;

namespace Condominios.Pruebas
{
    [TestFixture]
    public class Test05RegistrarService
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

            //Preparar datos para las pruebas de Residente
            Residente residente = new Residente();

            ResidenteDAO residenteDAO = (ResidenteDAO)Spring.GetObject("residenteDAO");
            residente.DNI = "40717629";
            residenteDAO.Eliminar(residente);
        }

        [Test]
        public void Test01RealizarRegistroResidente()
        {
            // 1. Instancia el objeto a probar
            Residente crearResidente = new Residente();

            // 2. Instanciando el objeto TO
            crearResidente.DNI = "40717629";
            crearResidente.Nombres = "Elía";
            crearResidente.ApellidoPaterno = "Torres";
            crearResidente.ApellidoMaterno = "Aguilar";
            crearResidente.Edad = 31;
            crearResidente.Correo = "lima@upc.edu.pe";
            crearResidente.Clave = "12345";
            crearResidente.Tipo = "R";

            //ReservaService reservaService = new ReservaService();
            RegistrarService registrarService = (RegistrarService)Spring.GetObject("registrarService");
            Assert.NotNull(registrarService);
            Residente residente = null;
            residente = registrarService.RegistrarResidente(crearResidente);
            Assert.NotNull(residente);

            crearResidente.DNI = "40717629";

            Assert.Catch<Exception>(delegate
            {
                residente = registrarService.RegistrarResidente(crearResidente);
            });

            crearResidente.DNI = "40717631";
            crearResidente.Correo = "lima@upc.edu.pe";

            Assert.Catch<Exception>(delegate
            {
                residente = registrarService.RegistrarResidente(crearResidente);
            });       
            
        }

        [Test]
        public void Test02RealizarRegistroVivienda()
        {
            // 1. Instancia el objeto a probar
            Vivienda crearVivienda = new Vivienda();
            Residente residente = new Residente();

            // Agregamos los valores del objeto TO
            residente.DNI = "40717629";
            crearVivienda.Ubicacion = "Lima";
            crearVivienda.Numero = 459;
            crearVivienda.Metraje = 200;
            crearVivienda.Tipo = "C";
            crearVivienda.Residente = residente;

            //ReservaService reservaService = new ReservaService();
            RegistrarService registrarService = (RegistrarService)Spring.GetObject("registrarService");
            Assert.NotNull(registrarService);
            Vivienda vivienda = null;
            vivienda = registrarService.RegistrarVivienda(crearVivienda);
            Assert.NotNull(vivienda);

            //limpiar datos de prueba
            registrarService.ViviendaDAO.Eliminar(vivienda);
            registrarService.ResidenteDAO.Eliminar(residente);
        }
    }
}