﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOAPService.Persistencia;
using SOAPService.Dominio;

namespace TestServicios
{
    [TestClass]
    public class TstServVivienda
    {
        ViviendaDAO dao = new ViviendaDAO();
        ResidenteDAO residenteDAO = new ResidenteDAO();
        DResidente residente = new DResidente();

        [TestMethod]
        public void crearVivienda()
        {
            residente.DNI = "40717626";

            DVivienda r = dao.Crear(new DVivienda()
            {
                Ubicacion = "San Borja",
                Numero = 459,
                Metraje = 200,
                Tipo = "C",
                Residente = residente
            });
            Assert.AreEqual(r.NumVivienda, 1);
        }

        //[TestMethod]
        //public void ObtenerVivienda()
        //{
        //    // 1. Instancia el objeto a probar
        //    Vivienda pruebaVivienda = new Vivienda();

        //    // 2. Instanciamos el objeto TO
        //    pruebaVivienda.NumVivienda = 3;

        //    // 3. Llamada al método del DAO a probar
        //    Vivienda viviendaObtenido = daoVivienda.Obtener(pruebaVivienda.NumVivienda);

        //    // 4. Implementar las validaciones
        //    Assert.NotNull(viviendaObtenido);
        //    Assert.AreEqual(pruebaVivienda.NumVivienda, viviendaObtenido.NumVivienda);
        //    Assert.NotNull(viviendaObtenido.Ubicacion);
        //}

        [TestMethod]
        public void modificarVivienda()
        {
            ViviendaDAO dao = new ViviendaDAO();
            DVivienda pruebaVivienda = new DVivienda();
            pruebaVivienda.NumVivienda = 0;
            residente = residenteDAO.Obtener("40717626");
            DVivienda viviendaOriginal = dao.Obtener(pruebaVivienda.NumVivienda);

            DVivienda r = dao.Modificar(new DVivienda()
            {
                NumVivienda = 0,
                Ubicacion = "Lima",
                Numero = 459,
                Metraje = 200,
                Tipo = "C",
                Residente = residente
            });
            Assert.AreNotEqual(viviendaOriginal.Ubicacion,r.Ubicacion);

            //// 1. Instancia el objeto a probar
            //DVivienda pruebaVivienda = new DVivienda();

            //// 2. Instanciamos el objeto TO
            //pruebaVivienda.NumVivienda = 0;
            //pruebaVivienda = dao.Obtener(pruebaVivienda.NumVivienda);
            //DVivienda viviendaOriginal = dao.Obtener(pruebaVivienda.NumVivienda);
            //pruebaVivienda.Ubicacion = "Callao";

            //// 3. Llamada al método del DAO a probar
            //DVivienda viviendaModificado = dao.Modificar(pruebaVivienda);

            //// 4. Implementar las validaciones
            //Assert.IsNotNull(viviendaModificado);
            //Assert.AreNotEqual(viviendaOriginal.Ubicacion, viviendaModificado.Ubicacion);
        }

        //[Test]
        //public void Test04Eliminar()
        //{
        //    // 1. Instancia el objeto a probar
        //    Vivienda pruebaVivienda = new Vivienda();
        //    Residente residente = new Residente();

        //    // 2. Instanciamos el objeto TO
        //    pruebaVivienda.NumVivienda = 3;

        //    // 3. Llamada al método del DAO a probar
        //    Assert.DoesNotThrow(delegate
        //    {
        //        daoVivienda.Eliminar(pruebaVivienda);
        //    });

        //    pruebaVivienda = daoVivienda.Obtener(pruebaVivienda.NumVivienda);
        //    // 4. Implementar las validaciones
        //    Assert.Null(pruebaVivienda);
        //}

        //[Test]
        //public void TestListar()
        //{

        //}
    }
}