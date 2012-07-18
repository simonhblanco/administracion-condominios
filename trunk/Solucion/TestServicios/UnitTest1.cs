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
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ResidenteDAO dao = new ResidenteDAO();
            DResidente r = dao.Crear(new DResidente() 
            { DNI = "12", 
              ApellidoPaterno = "Valenzuela",
              ApellidoMaterno = "Ñiquen",
              Nombres = "Ander",
              Edad = 30,
              Correo = "abc@campus.edu",
              Clave = "1234",              
              Tipo = "R"});
            Assert.AreEqual(r.DNI, "12");
        }
        [TestMethod]
        public void TestMethod2()
        {
            ResidenteDAO dao = new ResidenteDAO();
            DResidente r = dao.Modificar(new DResidente()
            {
                DNI = "12",
                ApellidoPaterno = "Valenzuela",
                ApellidoMaterno = "Ñiquen",
                Nombres = "Darwin Ander",
                Edad = 30,
                Correo = "abc@campus.edu",
                Clave = "1234",
                Tipo = "R"
            });
            Assert.AreEqual(r.DNI, "12");
        }

        [TestMethod]
        public void TestMethod3()
        {
            ResidenteDAO dao = new ResidenteDAO();
            DResidente r = dao.Eliminar(new DResidente()
            {
                DNI = "12"
            });
            Assert.AreEqual(r.DNI, "12");
        }

        [TestMethod]
        public void TestMethod4()
        {
            ResidenteDAO dao = new ResidenteDAO();
            ICollection<DResidente> LResidente = dao.ListarTodosLosResidentes();
            Assert.IsNotNull(LResidente);
            //Assert.Greater(LResidente.Count, 0);
        }
        
    }
}
