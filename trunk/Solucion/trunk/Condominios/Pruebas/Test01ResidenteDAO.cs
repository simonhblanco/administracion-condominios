using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Condominios.Persistencia;
using Condominios.Dominio;

namespace Condominios.Pruebas
{
    [TestFixture]
    public class Test01ResidenteDAO
    {
        //Instancia el objeto DAO a probar
        private ResidenteDAO residenteDAO = new ResidenteDAO();

        [Test]
        public void Test01Crear()
        {
            // 1. Instancia el objeto a probar
            Residente pruebaResidente = new Residente();

            // 2. Instanciando el objeto TO
            pruebaResidente.DNI = "40717622";
            pruebaResidente.Nombres = "Elía";
            pruebaResidente.ApellidoPaterno = "Torres";
            pruebaResidente.ApellidoMaterno = "Aguilar";
            pruebaResidente.Edad = 31;
            pruebaResidente.Correo = "peru@upc.edu.pe";
            pruebaResidente.Clave = "12345";
            pruebaResidente.Tipo = "R";

            // 3. Llamada al método del DAO a probar
            Residente residenteCreado = residenteDAO.Crear(pruebaResidente);

            // 4. Implementar las validaciones
            Assert.NotNull(residenteCreado);
            Assert.AreEqual(pruebaResidente.DNI, residenteCreado.DNI);
            Assert.AreEqual(pruebaResidente.Correo, residenteCreado.Correo);
        }

        [Test]
        public void Test02Obtener()
        {
            // 1. Instancia el objeto a probar
            Residente pruebaResidente = new Residente();

            // 2. Instanciamos el objeto TO
            pruebaResidente.DNI = "40717622";

            // 3. Llamada al método del DAO a probar
            Residente residenteObtenido = residenteDAO.Obtener(pruebaResidente.DNI);

            // 4. Implementar las validaciones
            Assert.NotNull(residenteObtenido);
            Assert.AreEqual(pruebaResidente.DNI, residenteObtenido.DNI);
            Assert.NotNull(residenteObtenido.ApellidoPaterno);
        }

        [Test]
        public void Test03Modificar()
        {
            // 1. Instancia el objeto a probar
            Residente pruebaResidente = new Residente();

            // 2. Instanciamos el objeto TO
            pruebaResidente.DNI = "40717622";
            pruebaResidente = residenteDAO.Obtener(pruebaResidente.DNI);
            Residente residenteOriginal = residenteDAO.Obtener(pruebaResidente.DNI);
            pruebaResidente.Correo = "inognisensoper@hotmail.com";

            // 3. Llamada al método del DAO a probar
            Residente residenteModificado = residenteDAO.Modificar(pruebaResidente);

            // 4. Implementar las validaciones
            Assert.NotNull(residenteModificado);
            Assert.AreNotEqual(residenteOriginal.Correo, residenteModificado.Correo);
        }
        
        [Test]
        public void Test04Eliminar()
        {
            // 1. Instancia el objeto a probar
            Residente pruebaResidente = new Residente();

            // 2. Instanciamos el objeto TO
            pruebaResidente.DNI = "40717622";
            // 3. Llamada al método del DAO a probar
            Assert.DoesNotThrow(delegate
            {
                residenteDAO.Eliminar(pruebaResidente);
            });

            pruebaResidente = residenteDAO.Obtener(pruebaResidente.DNI);
            // 4. Implementar las validaciones
            Assert.Null(pruebaResidente);
        }
        
        [Test]
        public void TestListar()
        {

        }
    }
}