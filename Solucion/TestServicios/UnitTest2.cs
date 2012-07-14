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
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            ResidenteDAO2 dao = new ResidenteDAO2();
            ResidenteEntidad r = dao.Crear(new ResidenteEntidad() { Dni = "12" });
            Assert.AreEqual(r.Dni, "12");
        }
    }
}
